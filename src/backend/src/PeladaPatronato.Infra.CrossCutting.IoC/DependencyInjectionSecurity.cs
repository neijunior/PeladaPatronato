using Microsoft.Extensions.DependencyInjection;
using PeladaPatronato.Infra.CrossCutting.Security.Acesso;

namespace PeladaPatronato.Infra.CrossCutting.IoC
{
  public static class DependencyInjectionSecurity
  {
    public static void RegisterSecurity(this IServiceCollection svcCollection)
    {
      svcCollection.AddScoped<IToken, Token>();
      
    }
  }
}
