using PeladaPatronato.Infra.CrossCutting.Request.Rodada;

namespace PeladaPatronato.Application.Rodada
{
  public interface IRodadaApplication
  {
    Task<Guid> CriarRodada(CriarRodadaRequest request);
    Task CriarTimes(CriarTimesRequest request);
    Task GerarPartidas(Guid rodadaId);
    Task SalvarEventos(SalvarEventosRequest request);
  }
}
