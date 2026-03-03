using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeladaPatronato.Infra.CrossCutting.Request.Rodada
{
  public class SalvarEventosRequest
  {
    public List<EventoItemRequest> Eventos { get; set; } = new();
  }

  public class EventoItemRequest
  {    
    public Guid TimeId { get; set; }
    public Guid ParticipanteId { get; set; }
    public int TipoEvento { get; set; }

    //public int Minuto { get; set; }
  }
}
