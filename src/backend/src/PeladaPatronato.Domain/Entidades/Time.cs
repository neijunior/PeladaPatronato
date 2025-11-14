using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeladaPatronato.Domain.Entidades
{
  public class Time
  {
    public Guid Id { get; set; }
    public Guid PartidaId { get; set; }
    public eCorColete CorColete { get; set; }

    public Time()
    {
      
    }

    public enum eCorColete
    {
      Amarelo = 1,
      Azul = 2,
      Preto = 3,
      Verde = 3
    }
  }
}
