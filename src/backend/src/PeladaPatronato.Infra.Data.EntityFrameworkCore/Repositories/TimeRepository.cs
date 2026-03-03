using PeladaPatronato.Domain.Entidades;
using PeladaPatronato.Domain.Interfaces;
using PeladaPatronato.Infra.Data.EntityFrameworkCore.Contexts;

namespace PeladaPatronato.Infra.Data.EntityFrameworkCore.Repositories
{
  public class TimeRepository : RepositoryBase<Time>, ITimeRepository
  {
    public TimeRepository(PeladaPatronatoDbContext context) : base(context)
    {
    }
  }
}
