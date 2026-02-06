using static PeladaPatronato.Domain.Enums;

namespace PeladaPatronato.Domain.Entidades
{
  public class EventoPartida
  {
    public Guid Id { get; set; }
    public Guid PartidaId { get; set; }
    public Guid ParticipanteId { get; set; }
    public eTipoEvento TipoEvento { get; set; }

    
  }
}
