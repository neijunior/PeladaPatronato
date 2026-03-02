using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeladaPatronato.Infra.CrossCutting.Request.Rodada
{
  public class ConsultarRodadaRequest
  {    
    public DateTime DataInicio { get; set; }
    public DateTime? DataFim  { get; set; }
  }
}
