using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PeladaPatronato.Domain.Enums;

namespace PeladaPatronato.Domain.Entidades
{
  public class RodadaEvento
  {
    public Guid Id { get; private set; }
    public Guid RodadaParticipanteId { get; private set; }
    public eTipoEvento Tipo { get; private set; }
    public int? Minuto { get; private set; }

    protected RodadaEvento() { }

    internal RodadaEvento(Guid rodadaParticipanteId, eTipoEvento tipo, int? minuto)
    {
      Id = Guid.NewGuid();
      RodadaParticipanteId = rodadaParticipanteId;
      Tipo = tipo;
      Minuto = minuto;
    }
  }

}
