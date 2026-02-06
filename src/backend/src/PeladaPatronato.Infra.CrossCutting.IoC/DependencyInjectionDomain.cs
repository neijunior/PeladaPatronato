using Microsoft.Extensions.DependencyInjection;
using PeladaPatronato.Domain;
using PeladaPatronato.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeladaPatronato.Infra.CrossCutting.IoC
{
  public static class DependencyInjectionDomain
  {
    public static void RegisterDomain(this IServiceCollection svcCollection)
    {
      //svcCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    }
  }
}
