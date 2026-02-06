using Microsoft.EntityFrameworkCore;
using PeladaPatronato.Domain;
using PeladaPatronato.Infra.Data.EntityFrameworkCore.Contexts;
using System.Linq.Expressions;

namespace PeladaPatronato.Infra.Data.EntityFrameworkCore.Repositories
{
  public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
  {
    //protected readonly PeladaPatronatoDbContext _context;
    //public RepositoryBase(PeladaPatronatoDbContext context)
    //{
    //  _context = context ?? throw new ArgumentNullException(nameof(context));
    //}

    //public Task<TEntity> Consultar<TEntity>(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes) where TEntity : class
    //{
    //  try
    //  {
    //    IQueryable<TEntity> query = _context.Set<TEntity>();
    //    foreach (Expression<Func<TEntity, object>> inc in includes)
    //      query = query.Include(inc);

    //    return query.FirstOrDefaultAsync(where);
    //  }
    //  catch (Exception ex)
    //  {

    //    throw ex;
    //  }
    //}

    //public Task<TEntity> ConsultarUltimo<TEntity>(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes) where TEntity : class
    //{
    //  throw new NotImplementedException();
    //}

    //public Task<int> Count<T1>(Func<T1, bool> where, params Expression<Func<T1, object>>[] includes) where T1 : class
    //{
    //  throw new NotImplementedException();
    //}

    //public Task Excluir(Guid Id)
    //{
    //  throw new NotImplementedException();
    //}

    //public Task Excluir(TEntity entity)
    //{
    //  throw new NotImplementedException();
    //}

    //public Task<bool> Existe<TEntity>(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes) where TEntity : class
    //{
    //  throw new NotImplementedException();
    //}

    //public async Task Salvar<TEntity>(TEntity entity) where TEntity : class
    //{
    //  try
    //  {
    //    _context.InitTransaction();

    //    var entry = _context.Entry(entity);

    //    if (entry.State == EntityState.Detached)
    //    {
    //      _context.Set<TEntity>().Attach(entity);
    //    }

    //    entry.State = entry.IsKeySet
    //        ? EntityState.Modified
    //        : EntityState.Added;

    //    await _context.SendChangesAsync();
    //  }
    //  catch
    //  {
    //    throw;
    //  }
    //}

    //public Task<ICollection<TEntity>> Listar<TEntity>(Func<TEntity, bool> where = null, params Expression<Func<TEntity, object>>[] includes) where TEntity : class
    //{
    //  throw new NotImplementedException();
    //}

    //public Task<ICollection<TEntity>> Listar()
    //{
    //  throw new NotImplementedException();
    //}

    //public Task<TEntity> Consultar(Guid Id)
    //{
    //  throw new NotImplementedException();
    //}

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
