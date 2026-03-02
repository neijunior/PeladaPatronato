using PeladaPatronato.Infra.CrossCutting.Request.Rodada;
using PeladaPatronato.Infra.CrossCutting.Response.Rodada;

namespace PeladaPatronato.Application.Rodada
{
  public interface IRodadaApplication
  {
    Task<ICollection<RodadaResponse>> Listar(ConsultarRodadaRequest request);
    Task<Guid> CriarRodada(CriarRodadaRequest request);
    Task CriarTimes(CriarTimesRequest request);
    Task GerarPartidas(Guid rodadaId);
    Task SalvarEventos(SalvarEventosRequest request);
  }
}
