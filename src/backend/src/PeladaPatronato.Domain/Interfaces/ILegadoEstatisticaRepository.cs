using PeladaPatronato.Domain.Entidades;
using PeladaPatronato.Infra.CrossCutting.Data;
using PeladaPatronato.Infra.CrossCutting.Request.Estatistica;

namespace PeladaPatronato.Domain.Interfaces
{
  public interface ILegadoEstatisticaRepository : IRepository<LegadoTotalEstatistica>
  {
    Task<IEnumerable<LegadoTotalEstatistica>> Listar(ConsultaEstatisticaRequest paramConsulta);
  }
}
