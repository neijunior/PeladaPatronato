using Microsoft.EntityFrameworkCore;

namespace PeladaPatronato.Infra.Data.EntityFrameworkCore
{
  public class PeladaPatronatoDbContext(DbContextOptions<PeladaPatronatoDbContext> options) : DbContext(options)
  {
    protected override void OnModelCreating(ModelBuilder builder)
    {
      SetTypePropertyDefault(builder);
      builder.ApplyConfigurationsFromAssembly(typeof(PeladaPatronatoDbContext).Assembly);
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
