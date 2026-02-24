using Microsoft.EntityFrameworkCore;
using PeladaPatronato.Domain.Entidades;
using PeladaPatronato.Domain.Interfaces;
using PeladaPatronato.Infra.CrossCutting.Request.Estatistica;
using PeladaPatronato.Infra.Data.EntityFrameworkCore.Contexts;

namespace PeladaPatronato.Infra.Data.EntityFrameworkCore.Repositories
{
  public class LegadoTotalEstatisticaRepository : RepositoryBase<LegadoTotalEstatistica>, ILegadoEstatisticaRepository
  {
    protected readonly PeladaPatronatoDbContext _context;
    public LegadoTotalEstatisticaRepository(PeladaPatronatoDbContext context) : base(context)
    {
      _context = context;
    }

    public async Task<IEnumerable<LegadoTotalEstatistica>> Listar(ConsultaEstatisticaRequest paramConsulta)
    {
      return await _context.LegadoTotalEstatistica.ToListAsync();
    }
  }
}
