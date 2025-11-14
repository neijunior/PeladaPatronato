using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeladaPatronato.Domain.Entidades
{
  public class Partida
  {
    public Guid Id { get; set; }
    public Guid RodadaId { get; set; }
    public int? OrdemPartida { get; set; }
  }
}
