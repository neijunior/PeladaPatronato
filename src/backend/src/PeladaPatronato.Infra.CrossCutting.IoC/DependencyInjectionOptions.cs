using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeladaPatronato.Infra.CrossCutting.IoC
{
  public static class DependencyInjectionOptions
  {
    public static void RegisterOptions(this IServiceCollection svcCollection, IConfiguration Configuration)
    {
      //svcCollection.Configure<FrameworkOptions>(Configuration.GetSection("FrameworkOptions"));
      //svcCollection.Configure<ReinfOptions>(Configuration.GetSection("ReinfOptions"));
    }
  }
}
