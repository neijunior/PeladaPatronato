using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeladaPatronato.Infra.CrossCutting.Request.Rodada
{
  public class CriarPartidaRequest
  {
    public Guid rodadaTimeAId { get; set; }
    public Guid rodadaTimeBId { get; set; }
    public int ordem { get; set; }
    public Guid timeComPosseInicialId { get; set; }    
  }
}
