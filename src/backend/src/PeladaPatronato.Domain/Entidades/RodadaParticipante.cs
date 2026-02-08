using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PeladaPatronato.Domain.Enums;

namespace PeladaPatronato.Domain.Entidades
{
  public class RodadaParticipante
  {
    public Guid Id { get; private set; }
    public Guid RodadaTimeId { get; private set; }
    public Guid ParticipanteId { get; private set; }
    public Posicao Posicao { get; private set; }

    private readonly List<RodadaEvento> _eventos = new();
    public IReadOnlyCollection<RodadaEvento> Eventos => _eventos;

    protected RodadaParticipante() { }

    internal RodadaParticipante(Guid rodadaTimeId, Guid participanteId, Posicao posicao)
    {
      Id = Guid.NewGuid();
      RodadaTimeId = rodadaTimeId;
      ParticipanteId = participanteId;
      Posicao = posicao;
    }

    public void RegistrarEvento(eTipoEvento tipo, int? minuto = null)
    {
      _eventos.Add(new RodadaEvento(Id, tipo, minuto));
    }
  }

}
