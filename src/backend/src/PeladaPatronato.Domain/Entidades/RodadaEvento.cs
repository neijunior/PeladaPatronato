using PeladaPatronato.Infra.CrossCutting.Data;

namespace PeladaPatronato.Domain.Entidades
{
  public class RodadaEvento : Entity
  {
    public Guid RodadaParticipanteId { get; private set; }
    public eTipoEvento Tipo { get; private set; }
    public int? Minuto { get; private set; }

    protected RodadaEvento() { }

    internal RodadaEvento(Guid rodadaParticipanteId, eTipoEvento tipo, int? minuto)
    {
      RodadaParticipanteId = rodadaParticipanteId;
      Tipo = tipo;
      Minuto = minuto;
    }
  }

}
