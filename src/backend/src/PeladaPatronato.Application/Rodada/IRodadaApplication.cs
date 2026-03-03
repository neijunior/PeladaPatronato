using PeladaPatronato.Infra.CrossCutting.Request.Rodada;
using PeladaPatronato.Infra.CrossCutting.Response;
using PeladaPatronato.Infra.CrossCutting.Response.Rodada;

namespace PeladaPatronato.Application.Rodada
{
  public interface IRodadaApplication
  {
    Task<PagedResponse<RodadaResponse>> Listar(ConsultarRodadaRequest request);
    Task<Guid> CriarRodada(CriarRodadaRequest request);
    Task CriarTimes(Guid rodadaId, CriarTimesRequest request);
    Task GerarPartidas(Guid rodadaId);
    Task SalvarEventos(Guid rodadaId, Guid partidaId, SalvarEventosRequest request);
    Task<RodadaResponse> ObterPorId(Guid rodadaId);
    Task AdicionarParticipante(Guid rodadaId, AdicionarParticipanteRequest request);
  }
}
