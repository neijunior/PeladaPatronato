using Microsoft.Extensions.DependencyInjection;
using PeladaPatronato.Application.Core.Participante;
using PeladaPatronato.Application.Participante;

namespace PeladaPatronato.Infra.CrossCutting.IoC
{
  internal static class ApplicationServices
  {
    internal static IServiceCollection AddApplication(this IServiceCollection services)
    {
      return services
          .AddScoped<IParticipanteApplication, ParticipanteApplication>();          
    }
  }
}
