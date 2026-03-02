using PeladaPatronato.Infra.CrossCutting.Data;

namespace PeladaPatronato.Domain.Entidades
{
  public class RodadaPartidaParticipante : Entity
  {
    public Guid RodadaPartidaId { get; private set; }
    public Guid RodadaTimeParticipanteId { get; private set; }

    public RodadaPartidaParticipante()
    {
        
    }
  }
}