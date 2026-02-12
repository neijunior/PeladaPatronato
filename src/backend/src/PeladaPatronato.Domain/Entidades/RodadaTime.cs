using PeladaPatronato.Infra.CrossCutting.Data;

namespace PeladaPatronato.Domain.Entidades
{
  public class RodadaTime : Entity
  {
    public Guid RodadaId { get; private set; }
    public Guid TimeId { get; private set; }

    public int Vitorias { get; private set; }
    public int Derrotas { get; private set; }
    public int Empates { get; private set; }
    public int GolsPro { get; private set; }
    public int GolsContra { get; private set; }

    private readonly List<RodadaParticipante> _participantes = new();
    public IReadOnlyCollection<RodadaParticipante> Participantes => _participantes;

    private readonly List<RodadaPartida> _partidas = new();
    public IReadOnlyCollection<RodadaPartida> Partidas => _partidas;

    protected RodadaTime() { }

    internal RodadaTime(Guid rodadaId, Guid timeId)
    {
      RodadaId = rodadaId;
      TimeId = timeId;
    }

    public RodadaParticipante AdicionarParticipante(Guid participanteId, eCategoriaPosicao categoriaPosicao)
    {
      var rp = new RodadaParticipante(Id, participanteId, categoriaPosicao);
      _participantes.Add(rp);
      return rp;
    }

    internal void RegistrarResultado(int golsPro, int golsContra)
    {
      GolsPro += golsPro;
      GolsContra += golsContra;

      if (golsPro > golsContra) Vitorias++;
      else if (golsPro < golsContra) Derrotas++;
      else Empates++;
    }
  }

}
