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
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? OrderBy { get; set; }
  }
}
