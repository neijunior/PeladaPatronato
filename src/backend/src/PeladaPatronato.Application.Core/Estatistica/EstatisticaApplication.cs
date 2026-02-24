using PeladaPatronato.Application.Estatistica;
using PeladaPatronato.Domain.Interfaces;
using PeladaPatronato.Infra.CrossCutting.Request.Estatistica;
using PeladaPatronato.Infra.CrossCutting.Response.Estatistica;

namespace PeladaPatronato.Application.Core.Estatistica
{
  public class EstatisticaApplication : IEstatisticaApplication
  {
    private readonly ILegadoTotalEstatisticaRepository _legadoEstatisticaRepository;
    public EstatisticaApplication(ILegadoTotalEstatisticaRepository legadoEstatisticaRepository)
    {
      _legadoEstatisticaRepository = legadoEstatisticaRepository;
    }
    public Task<IEnumerable<EstatisticaResponse>> Listar(ConsultaEstatisticaRequest paramConsulta)
    {
      throw new NotImplementedException();
    }
  }
}
