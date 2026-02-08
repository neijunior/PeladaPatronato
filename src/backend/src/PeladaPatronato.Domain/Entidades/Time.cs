using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeladaPatronato.Domain.Entidades
{
  public class Time
  {
    public Guid Id { get; private set; }
    public string Nome { get; private set; } = null!;

    public Time()
    {
      
    }
  }
}
