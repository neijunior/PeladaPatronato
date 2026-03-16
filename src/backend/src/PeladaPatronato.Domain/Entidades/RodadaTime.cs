using PeladaPatronato.Infra.CrossCutting.Data;

namespace PeladaPatronato.Domain.Entidades
{
  public class RodadaTime : Entity
  {
    public Guid RodadaId { get; private set; }
    public Guid TimeBaseId { get; private set; }

    public int Vitorias { get; private set; }
    public int Derrotas { get; private set; }
    public int Empates { get; private set; }
    public int GolsPro { get; private set; }
    public int GolsContra { get; private set; }
    public virtual Rodada? Rodada { get; private set; }
    public virtual Time? Time { get; private set; }
    private readonly List<RodadaTimeParticipante> _participantes = new();
    public IReadOnlyCollection<RodadaTimeParticipante> Participantes => _participantes;
    protected RodadaTime() { }

    public RodadaTime(Guid rodadaId, Guid timeBaseId)
    {
      Id = Guid.NewGuid();
      RodadaId = rodadaId;
      TimeBaseId = timeBaseId;
    }

    public void AdicionarParticipante(Guid participanteId)
    {
      _participantes.Add(new RodadaTimeParticipante(Id, participanteId));
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

  public class CriarTimeInfo
  {
    public Guid TimeBaseId { get; }
    public IEnumerable<Guid> ParticipantesIds { get; }

    public CriarTimeInfo(Guid timeBaseId, IEnumerable<Guid> participantesIds)
    {
      TimeBaseId = timeBaseId;
      ParticipantesIds = participantesIds;
    }
  }

}
