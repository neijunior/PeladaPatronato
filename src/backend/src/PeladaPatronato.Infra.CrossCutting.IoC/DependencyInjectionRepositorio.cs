using Microsoft.Extensions.DependencyInjection;
using PeladaPatronato.Domain.Interfaces;
using PeladaPatronato.Infra.Data.EntityFrameworkCore.Repositories;

namespace PeladaPatronato.Infra.CrossCutting.IoC
{
  public static class DependencyInjectionRepositorio
  {
    public static void RegisterRepositorio(this IServiceCollection svcCollection)
    {      
      svcCollection.AddScoped<IParticipanteRepository, ParticipanteRepository>();
      svcCollection.AddScoped<IPosicaoRepository, PosicaoRepository>();
      svcCollection.AddScoped<ILegadoTotalEstatisticaRepository, LegadoTotalEstatisticaRepository>();
    }
  }
}
