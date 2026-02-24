using PeladaPatronato.Infra.CrossCutting.Request.Estatistica;
using PeladaPatronato.Infra.CrossCutting.Response.Estatistica;

namespace PeladaPatronato.Application.Estatistica
{
  public interface IEstatisticaApplication
  {
    Task<IEnumerable<EstatisticaResponse>> Listar(ConsultaEstatisticaRequest paramConsulta);
  }
}
