using PeladaPatronato.Infra.CrossCutting.Request.Estatistica;
using PeladaPatronato.Infra.CrossCutting.Response;
using PeladaPatronato.Infra.CrossCutting.Response.Estatistica;

namespace PeladaPatronato.Application.Estatistica
{
  public interface IEstatisticaApplication
  {
    Task<PagedResponse<EstatisticaResponse>> Listar(ConsultaEstatisticaRequest paramConsulta);
  }
}
