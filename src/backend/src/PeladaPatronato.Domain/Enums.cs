using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeladaPatronato.Domain
{
  public class Enums
  {
    public enum ePosicao
    {
      Goleiro = 1,
      Fixo = 2,
      Ala = 3,
      Pivo = 4
    }

    public enum eTipoEvento
    {
      Assistencia = 1,
      Gol = 2
    }
  }
}
