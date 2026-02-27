using PeladaPatronato.Infra.CrossCutting.Request.Participante;
using PeladaPatronato.Infra.CrossCutting.Response;
using PeladaPatronato.Infra.CrossCutting.Response.Participante;

namespace PeladaPatronato.Application.Participante
{
  public interface IParticipanteApplication
  {
    Task<ParticipanteResponse?> Consultar(Guid Id);
    Task<ParticipanteResponse> Salvar(ParticipanteRequest participante);
    Task<PagedResponse<ParticipanteResponse>> Listar(ConsultaParticipanteRequest paramConsulta);
    Task<ParticipanteResponse> Inativar(Guid id);  
  }
}
