using System.Linq.Expressions;

namespace PeladaPatronato.Infra.CrossCutting.Data
{
  public interface IRepository<TEntity> where TEntity : class
  {
    Task<TEntity?> ObterPorId(Guid id);
    Task<TEntity?> Consultar(Expression<Func<TEntity, bool>> where);
    Task<IReadOnlyCollection<TEntity>> Listar(Expression<Func<TEntity, bool>>? filtro = null, Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null, bool asNoTracking = true);
    Task Remover(TEntity entity);
    Task<TEntity> Adicionar(TEntity entity);
    Task<TEntity> Atualizar(TEntity entity);
  }
}
