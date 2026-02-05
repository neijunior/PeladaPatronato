using PeladaPatronato.Application.Request.Participante;
using PeladaPatronato.Application.Response.Participante;

namespace PeladaPatronato.Application.Participante
{
  public interface IParticipanteApplication
  {
    Task<ParticipanteResponse> Consultar(Guid Id);
    Task<ParticipanteResponse> Salvar(ParticipanteRequest participante);
    Task<IEnumerable<ParticipanteResponse>> Listar();
    Task<ParticipanteResponse> Inativar();
  }
}
