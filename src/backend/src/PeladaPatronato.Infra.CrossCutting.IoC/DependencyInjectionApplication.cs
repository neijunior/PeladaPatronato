using Microsoft.Extensions.DependencyInjection;
using PeladaPatronato.Application.Core.Generico;
using PeladaPatronato.Application.Core.Participante;
using PeladaPatronato.Application.Generico;
using PeladaPatronato.Application.Participante;

namespace PeladaPatronato.Infra.CrossCutting.IoC
{
  public static class DependencyInjectionApplication
  {
    public static void RegisterApplication(this IServiceCollection svcCollection)
    {
      svcCollection.AddScoped<IParticipanteApplication, ParticipanteApplication>();
      svcCollection.AddScoped<IGenericoApplication, GenericoApplication>();
    }
  }
}
