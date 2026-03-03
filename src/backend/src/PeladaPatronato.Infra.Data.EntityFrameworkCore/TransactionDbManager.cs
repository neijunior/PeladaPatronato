using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PeladaPatronato.Infra.CrossCutting.Data;
using PeladaPatronato.Infra.Data.EntityFrameworkCore.Contexts;

namespace PeladaPatronato.Infra.Data.EntityFrameworkCore
{
  public class TransactionDbManager: IUnitOfWork, IDisposable
  {
    private readonly PeladaPatronatoDbContext _db;

    private IDbContextTransaction? _transaction;

    public TransactionDbManager(PeladaPatronatoDbContext db)
    {
      _db = db;
    }

    public void BeginTransaction()
    {
      _transaction = _db.Database.BeginTransaction();
    }

    public void Commit()
    {
      if (_transaction != null)
      {
        _transaction.Commit();
      }
    }

    public async Task CommitAsync()
    {
      if (_transaction != null)
      {
        await _db.SaveChangesAsync();
        await _transaction.CommitAsync();
      }
    }

    public void Rollback()
    {
      if (_transaction != null)
        _transaction.Rollback();
    }
    public void Dispose()
    {
      _transaction?.Dispose();
      _transaction = null;
    }
  }
}
