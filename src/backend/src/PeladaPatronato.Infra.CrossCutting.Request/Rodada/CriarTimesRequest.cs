using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeladaPatronato.Infra.CrossCutting.Request.Rodada
{
  public class CriarTimesRequest
  {
    public Guid rodadaId { get; set; }
    public List<CriarTimeItemRequest> Times { get; set; } = new();
  }

  public class CriarTimeItemRequest
  {
    public Guid TimeId { get; set; }
    public List<Guid> ParticipantesIds { get; set; } = new();
  }
}
