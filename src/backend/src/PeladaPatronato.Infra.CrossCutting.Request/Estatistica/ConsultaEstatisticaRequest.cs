using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeladaPatronato.Infra.CrossCutting.Request.Estatistica
{
  public class ConsultaEstatisticaRequest
  {
    public string NomeParticipante { get; set; } = string.Empty;
    public int? Posicao { get; set; }
    public string Periodo { get; set; } = string.Empty;
    public DateTime? DataInicio { get; set; }
    public DateTime? DataFim { get; set; }
  }
}
