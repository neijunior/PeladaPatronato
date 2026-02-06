using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PeladaPatronato.Domain
{
  public interface IRepository<TEntity> where TEntity : class
  {
    //Task Excluir(Guid Id);
    //Task Excluir(T entity);   
    //Task<T> Consultar(Guid Id);
    //Task<ICollection<T>> Listar();
    //Task<TEntity> Consultar<TEntity>(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes) where TEntity : class;
    //Task<bool> Existe<T>(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes) where T : class;
    //Task<TEntity> ConsultarUltimo<TEntity>(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes) where TEntity : class;
    //Task<ICollection<TEntity>> Listar<TEntity>(Func<TEntity, bool> where = null, params Expression<Func<TEntity, object>>[] includes) where TEntity : class;
    //Task<int> Count<T>(Func<T, bool> where, params Expression<Func<T, object>>[] includes) where T : class;
    //Task Salvar<T>(T entity) where T : class;

    Task<TEntity?> ObterPorId(Guid id);
    Task<TEntity?> Consultar(Expression<Func<TEntity, bool>> where);
    Task<IReadOnlyCollection<TEntity>> Listar(Expression<Func<TEntity, bool>>? filtro = null, Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null,bool asNoTracking = true);    
    Task Remover(TEntity entity);
    Task<TEntity> Adicionar(TEntity entity);
    Task<TEntity> Atualizar(TEntity entity);
  }
}
