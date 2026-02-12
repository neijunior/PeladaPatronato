namespace PeladaPatronato.Infra.CrossCutting.Data
{
  public interface IUnitOfWork
  {
    void BeginTransaction();

    void Commit();

    void Rollback();
  }
}
