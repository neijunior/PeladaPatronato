using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeladaPatronato.Infra.CrossCutting.Request.Rodada
{
  public class AdicionarParticipanteRequest
  {
    public Guid ParticipanteId { get; set; }
    public bool Diarista { get; set; }
  }
}
