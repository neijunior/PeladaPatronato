using Microsoft.EntityFrameworkCore;
using PeladaPatronato.Infra.CrossCutting.Data;
using PeladaPatronato.Infra.Data.EntityFrameworkCore.Contexts;
using System.Linq.Expressions;

namespace PeladaPatronato.Infra.Data.EntityFrameworkCore.Repositories
{
  public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
  {
    protected readonly PeladaPatronatoDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public RepositoryBase(PeladaPatronatoDbContext context)
    {
      _context = context;
      _dbSet = context.Set<TEntity>();
    }

    public async Task<TEntity?> ObterPorId(Guid id)
        => await _dbSet.FindAsync(id);

    public async Task<TEntity?> Consultar(Expression<Func<TEntity, bool>> where)
        => await _dbSet.FirstOrDefaultAsync(where);

    public async Task<IReadOnlyCollection<TEntity>> Listar(Expression<Func<TEntity, bool>>? filtro = null, Func<IQueryable<TEntity>,
                                                           IQueryable<TEntity>>? include = null, bool asNoTracking = true)
    {
      IQueryable<TEntity> query = _dbSet;

      if (asNoTracking)
        query = query.AsNoTracking();

      if (include is not null)
        query = include(query);

      if (filtro is not null)
        query = query.Where(filtro);

      return await query.ToListAsync();
    }


    public async Task<TEntity> Adicionar(TEntity entity)
    {
      await _dbSet.AddAsync(entity);
      await _context.SaveChangesAsync();
      return entity;
    }

    public async Task<TEntity> Atualizar(TEntity entity)
    {
      _dbSet.Update(entity);
      await _context.SaveChangesAsync();
      return entity;
    }

    public async Task Remover(TEntity entity)
    {
      _dbSet.Remove(entity);
      await _context.SaveChangesAsync();
    }
  }
}
