using Microsoft.Extensions.DependencyInjection;
using PeladaPatronato.Domain.Interfaces;
using PeladaPatronato.Infra.Data.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeladaPatronato.Infra.CrossCutting.IoC
{
  public static class DependencyInjectionRepositorio
  {
    public static void RegisterRepositorio(this IServiceCollection svcCollection)
    {      
      svcCollection.AddScoped<IParticipanteRepository, ParticipanteRepository>();
      svcCollection.AddScoped<IPosicaoRepository, PosicaoRepository>();
    }
  }
}
