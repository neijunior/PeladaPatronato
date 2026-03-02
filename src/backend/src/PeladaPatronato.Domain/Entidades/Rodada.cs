using PeladaPatronato.Infra.CrossCutting.Data;

namespace PeladaPatronato.Domain.Entidades
{
  public class Rodada : IAggregateRoot
  {
    public Guid Id { get; private set; }
    public DateTime DataHora { get; private set; }
    public decimal ValorDiarista { get; private set; }
    public string? Observacao { get; private set; }
    public TimeSpan TempoTotal { get; private set; }
    public TimeSpan TempoPorPartida { get; private set; }
    public StatusRodada Status { get; private set; }
    private readonly List<RodadaTime> _times = new();
    private readonly List<RodadaPartida> _partidas = new();
    public IReadOnlyCollection<RodadaTime> Times => _times;
    public IReadOnlyCollection<RodadaPartida> Partidas => _partidas;
    protected Rodada() { } // EF
    public Rodada(DateTime dataHora, decimal valorDiarista, string? observacao, TimeSpan tempoTotal, TimeSpan tempoPorPartida)
    {
      if (tempoTotal <= TimeSpan.Zero)
        throw new Exception("Tempo total inválido.");

      if (tempoPorPartida <= TimeSpan.Zero)
        throw new Exception("Tempo por partida inválido.");

      if (tempoTotal < tempoPorPartida)

        Id = Guid.NewGuid();
      DataHora = dataHora;
      ValorDiarista = valorDiarista;
      Observacao = observacao;
      TempoTotal = tempoTotal;
      TempoPorPartida = tempoPorPartida;
      Status = StatusRodada.Criada;
    }
    public void DefinirTimes(IEnumerable<CriarTimeInfo> lista)
    {
      if (Status != StatusRodada.Criada)
        throw new Exception("Times só podem ser definidos quando a rodada estiver criada.");

      _times.Clear();

      foreach (var item in lista)
      {
        var time = new RodadaTime(this.Id, item.TimeBaseId);

        foreach (var part in item.ParticipantesIds)
          time.AdicionarParticipante(part);

        _times.Add(time);
      }

      Status = StatusRodada.TimesDefinidos;
    }
    public void GerarPartidas()
    {
      if (Status != StatusRodada.TimesDefinidos)
        throw new Exception("Não é possível gerar partidas neste momento.");

      _partidas.Clear();
      _partidas.AddRange(GerarConfrontos());

      Status = StatusRodada.PartidasGeradas;
    }
    private List<RodadaPartida> GerarConfrontos()
    {
      var partidas = new List<RodadaPartida>();

      int maxPartidas = (int)(TempoTotal.TotalMinutes / TempoPorPartida.TotalMinutes);

      if (maxPartidas <= 0)
        throw new Exception("Tempo insuficiente para gerar partidas.");

      var cicloBase = new List<(Guid A, Guid B)>();

      for (int i = 0; i < _times.Count; i++)
      {
        for (int j = i + 1; j < _times.Count; j++)
        {
          cicloBase.Add((_times[i].Id, _times[j].Id));
        }
      }

      int ordem = 1;
      int indiceCiclo = 0;
      var controleConsecutivos = new Dictionary<Guid, int>();

      while (partidas.Count < maxPartidas)
      {
        var confronto = cicloBase[indiceCiclo];

        if (PodeInserir(confronto, controleConsecutivos))
        {
          var partida = new RodadaPartida(this.Id, confronto.A, confronto.B, ordem);
          partidas.Add(partida);

          AtualizarControleConsecutivo(confronto, controleConsecutivos);
          ordem++;
        }

        indiceCiclo++;
        if (indiceCiclo >= cicloBase.Count)
          indiceCiclo = 0;
      }

      DistribuirPosseInicial(partidas);

      return partidas;
    }
    private bool PodeInserir((Guid A, Guid B) confronto, Dictionary<Guid, int> controle)
    {
      if (!controle.ContainsKey(confronto.A)) controle[confronto.A] = 0;
      if (!controle.ContainsKey(confronto.B)) controle[confronto.B] = 0;

      return controle[confronto.A] < 2 && controle[confronto.B] < 2;
    }
    private void AtualizarControleConsecutivo((Guid A, Guid B) confronto, Dictionary<Guid, int> controle)
    {
      foreach (var key in controle.Keys.ToList())
        controle[key] = 0;

      controle[confronto.A]++;
      controle[confronto.B]++;
    }
    private void DistribuirPosseInicial(List<RodadaPartida> partidas)
    {
      var controlePosse = new Dictionary<Guid, int>();
      Guid? ultimoComPosse = null;

      foreach (var partida in partidas.OrderBy(p => p.Ordem))
      {
        if (!controlePosse.ContainsKey(partida.RodadaTimeAId))
          controlePosse[partida.RodadaTimeAId] = 0;

        if (!controlePosse.ContainsKey(partida.RodadaTimeBId))
          controlePosse[partida.RodadaTimeBId] = 0;

        Guid escolhido;

        if (controlePosse[partida.RodadaTimeAId] <
            controlePosse[partida.RodadaTimeBId])
        {
          escolhido = partida.RodadaTimeAId;
        }
        else if (controlePosse[partida.RodadaTimeAId] >
                 controlePosse[partida.RodadaTimeBId])
        {
          escolhido = partida.RodadaTimeBId;
        }
        else
        {
          // Evita 2 posses seguidas
          escolhido = ultimoComPosse == partida.RodadaTimeAId
              ? partida.RodadaTimeBId
              : partida.RodadaTimeAId;
        }

        partida.DefinirPosseInicial(escolhido);

        controlePosse[escolhido]++;
        ultimoComPosse = escolhido;
      }
    }
    public void RegistrarEventosEmLote(IEnumerable<(Guid partidaId, eTipoEvento tipo, Guid rodadaTimeId, Guid participanteId)> eventos)
    {
      if (Status != StatusRodada.PartidasGeradas)
        throw new Exception("Eventos só podem ser registrados após gerar partidas.");

      foreach (var e in eventos)
      {
        var partida = _partidas.FirstOrDefault(p => p.Id == e.partidaId)
                      ?? throw new Exception("Partida não pertence a esta rodada.");

        partida.RegistrarEvento(e.tipo, e.rodadaTimeId, e.participanteId);
      }
    }
  }
  public enum StatusRodada
  {
    Criada = 1,
    TimesDefinidos = 2,
    PartidasGeradas = 3,
    Finalizada = 4
  }
}
