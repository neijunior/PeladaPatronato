using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PeladaPatronato.Domain.Interfaces;
using PeladaPatronato.Infra.Data.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeladaPatronato.Infra.CrossCutting.IoC
{
  internal static class DataServices
  {
    internal static IServiceCollection AddData(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
      return services
        .AddBancoDeDados(configuration)        
        .AddRepository();
    }

    private static IServiceCollection AddBancoDeDados(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
      return services.AddDbContext<PeladaPatronatoDbContext>(options =>
      {
        options.UseSqlServer(
                  configuration.GetConnectionString("DefaultConnection"),
                  b =>
                  {
                    b.MigrationsAssembly("GWS.Catalogo.Infra.Data.EntityFrameworkCore");
                    b.CommandTimeout(600);
                  }
              );
      });
    }
    private static IServiceCollection AddRepository(this IServiceCollection services)
    {
      return services
          .AddScoped<IParticipanteRepository, ParticipanteRepository>();
          //.AddScoped<IUnitOfWork, TransactionDbManagerCatalogo>()
          
    }
  }
}
