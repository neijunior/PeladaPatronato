using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeladaPatronato.Domain.Entidades
{
  public class EventoPartida
  {
    public Guid Id { get; set; }
    public Guid PartidaId { get; set; }
    public Guid ParticipanteId { get; set; }
    public eTipoEvento TipoEvento { get; set; }

    public enum eTipoEvento
    {
      Assistencia = 1,
      Gol = 2
    }
  }
}
