using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PeladaPatronato.Domain.Entidades;

namespace PeladaPatronato.Infra.Data.EntityFrameworkCore.Contexts
{
  public class PeladaPatronatoDbContext : DbContext
  {
    public DbSet<Participante> Participante { get; set; }
    public DbSet<LegadoTotalEstatistica> LegadoTotalEstatistica { get; set; }
    
    public IDbContextTransaction Transaction { get; private set; }
    public PeladaPatronatoDbContext(DbContextOptions<PeladaPatronatoDbContext> options) : base(options)
    {
      if (Database.GetPendingMigrations().Count() > 0)
        Database.Migrate();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    public IDbContextTransaction InitTransaction()
    {
      if (Transaction == null) Transaction = this.Database.BeginTransaction();
      return Transaction;
    }

    private void RollBack()
    {
      if (Transaction != null) Transaction.Rollback();
    }

    private void Save()
    {
      try
      {
        ChangeTracker.DetectChanges();
        SaveChanges();
      }
      catch (Exception ex)
      {
        RollBack();
        throw new Exception(ex.Message);
      }
    }

    private void Commit()
    {
      if (Transaction != null)
      {
        Transaction.Commit();
        Transaction.Dispose();
        Transaction = null;
      }
    }

    public void SendChanges()
    {
      Save();
      Commit();
    }

    public async Task SendChangesAsync()
    {
      await SaveChangesAsync();
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
      SetTypePropertyDefault(builder);
      builder.ApplyConfigurationsFromAssembly(typeof(PeladaPatronatoDbContext).Assembly);
      builder.PopularTabela(); 
      base.OnModelCreating(builder);
    }

    private void SetTypePropertyDefault(ModelBuilder builder)
    {
      foreach (var property in builder.Model.GetEntityTypes().SelectMany(e => e.GetProperties()))
      {
        if (property.ClrType == typeof(string))
          property.SetColumnType("varchar(200)");
        else if (property.ClrType == typeof(decimal) || property.ClrType == typeof(decimal?))
          property.SetColumnType("decimal(15,2)");
        else if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
          property.SetColumnType("datetime");
      }
    }
  }
}
