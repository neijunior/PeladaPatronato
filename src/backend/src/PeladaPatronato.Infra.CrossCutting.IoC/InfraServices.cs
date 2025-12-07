using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PeladaPatronato.Infra.CrossCutting.IoC
{
  public static class InfraServices
  {
    public static IServiceCollection AddInfraCatalogo<T>(this IServiceCollection services, IConfiguration configuration)
    {
      return services
          .AddData(configuration)          
          .AddApplication();
    }
  }
}
