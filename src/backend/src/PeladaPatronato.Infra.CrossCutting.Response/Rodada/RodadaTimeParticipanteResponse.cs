using PeladaPatronato.Infra.CrossCutting.Response.Participante;

namespace PeladaPatronato.Infra.CrossCutting.Response.Rodada
{
  public class RodadaTimeParticipanteResponse
  {
    public Guid TimeBaseId { get; set; }
    public ICollection<ParticipanteResponse> Participantes { get; set; } = new List<ParticipanteResponse>();
  }
}