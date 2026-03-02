using PeladaPatronato.Infra.CrossCutting.Request.Participante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeladaPatronato.Infra.CrossCutting.Request.Rodada
{
  public class CriarRodadaRequest
  {
    public DateTime DataHora { get; set; }
    public int MinutosPartida { get; set; }    
    public decimal ValorDiarista { get; set; }
    public string? Observacao { get; set; }
    public TimeSpan TempoTotal { get; set; }
    public TimeSpan TempoPorPartida { get; set; }
  }
}
