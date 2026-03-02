using PeladaPatronato.Infra.CrossCutting.Data;

namespace PeladaPatronato.Domain.Entidades
{
  public class RodadaPartidaEvento : Entity
  {
    public Guid RodadaPartidaId { get; private set; }
    public eTipoEvento TipoEvento { get; private set; }
    public Guid RodadaTimeId { get; private set; }
    public Guid RodadaPartidaParticipanteId { get; private set; }        
    protected RodadaPartidaEvento() { }

    internal RodadaPartidaEvento(Guid rodadaPartidaId, Guid rodadaTimeId, Guid rodadaPartidaParticipanteId, eTipoEvento tipoEvento)
    { 
      RodadaPartidaId = rodadaPartidaId;
      RodadaTimeId = rodadaTimeId;
      RodadaPartidaParticipanteId = rodadaPartidaParticipanteId;
      TipoEvento = tipoEvento;
    }
  }

  public enum eTipoEvento
  {
    Gol = 1,
    Assistencia = 2
  }

}
