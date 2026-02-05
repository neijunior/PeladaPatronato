using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PeladaPatronato.Infra.Data.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeladaPatronato.Infra.CrossCutting.IoC
{
  public static class DependencyInjection
  {
    public static void Register(this IServiceCollection svcCollection, IConfiguration Configuration)
    {

      //Application
      svcCollection.RegisterApplication();
      //Domínio
      svcCollection.RegisterDomain();
      //Repositorio
      svcCollection.RegisterRepositorio();
      //svcCollection.RegisterInfraGeneration();
      //svcCollection.RegisterInfraIntegration();

      svcCollection.AddSqlConfiguration(Configuration);
      svcCollection.RegisterOptions(Configuration);
    }

    private static void AddSqlConfiguration(this IServiceCollection svcCollection, IConfiguration configuration)
    {
      svcCollection.AddDbContext<PeladaPatronatoDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("ConnAtivo"), b =>
      {
        b.MigrationsAssembly("PeladaPatronato.Infra.Data.EntityFrameworkCore");
        opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

      }));
    }
  }
}
