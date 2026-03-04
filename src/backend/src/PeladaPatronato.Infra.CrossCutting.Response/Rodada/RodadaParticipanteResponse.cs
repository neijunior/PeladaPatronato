using PeladaPatronato.Infra.CrossCutting.Response.Participante;

namespace PeladaPatronato.Infra.CrossCutting.Response.Rodada
{
  public class RodadaParticipanteResponse
  {
    public ParticipanteResponse? Participante { get; set; }
    public bool? Diarista { get; set; }
    public bool? Pago { get; set; }
  }
}