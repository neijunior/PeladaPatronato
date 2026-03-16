using PeladaPatronato.Infra.CrossCutting.Data;

namespace PeladaPatronato.Domain.Entidades
{
  public class RodadaTimeParticipante : Entity
  {
    public Guid RodadaTimeId { get; private set; }
    public Guid ParticipanteId { get; private set; }

    public virtual RodadaTime? RodadaTime { get; private set; }
    public virtual Participante? Participante { get; private set; }

    protected RodadaTimeParticipante() { }

    public RodadaTimeParticipante(Guid rodadaTimeId, Guid participanteId)
    {
      RodadaTimeId = rodadaTimeId;
      ParticipanteId = participanteId;
    }
  }
}