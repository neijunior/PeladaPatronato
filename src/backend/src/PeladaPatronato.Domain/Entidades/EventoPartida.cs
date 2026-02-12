using PeladaPatronato.Infra.CrossCutting.Data;

namespace PeladaPatronato.Domain.Entidades
{
  public class EventoPartida : Entity
  {
    public Guid PartidaId { get; set; }
    public Guid ParticipanteId { get; set; }
    public eTipoEvento TipoEvento { get; set; }
    public DateTime DataHoraEvento { get; set; }

    public EventoPartida(Guid partidaId, Guid participanteId, eTipoEvento tipoEvento, DateTime dataHoraEvento)
    {
      PartidaId = partidaId;
      ParticipanteId = participanteId;
      TipoEvento = tipoEvento;
      DataHoraEvento = dataHoraEvento;
    }
  }

  public enum eTipoEvento
  {
    Assistencia = 1,
    Gol = 2
  }
}
