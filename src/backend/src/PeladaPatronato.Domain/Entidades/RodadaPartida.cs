using PeladaPatronato.Infra.CrossCutting.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeladaPatronato.Domain.Entidades
{
  public class RodadaPartida : Entity
  {
    public Guid RodadaId { get; private set; }
    public Guid RodadaTimeAId { get; private set; }
    public Guid RodadaTimeBId { get; private set; }
    public int Ordem { get; private set; }
    public Guid? TimeComPosseInicialId { get; private set; }
    public DateTime? DataHora { get; private set; }
    private readonly List<RodadaPartidaParticipante> _participantes = new();
    public IReadOnlyCollection<RodadaPartidaParticipante> Participantes => _participantes;

    private readonly List<RodadaPartidaEvento> _eventos = new();
    public IReadOnlyCollection<RodadaPartidaEvento> Eventos => _eventos;
    //public Rodada Rodada { get; private set; }

    protected RodadaPartida() { }

    public RodadaPartida(Guid rodadaId, Guid rodadaTimeAId, Guid rodadaTimeBId, int ordem)
    {
      RodadaId = rodadaId;
      RodadaTimeAId = rodadaTimeAId;
      RodadaTimeBId = rodadaTimeBId;
      Ordem = ordem;
    }

    public void DefinirPosseInicial(Guid timeId)
    {
      TimeComPosseInicialId = timeId;
    }
    public void RegistrarEvento(eTipoEvento tipo, Guid rodadaTimeId, Guid participanteId)
    {
      if (rodadaTimeId != RodadaTimeAId && rodadaTimeId != RodadaTimeBId)
        throw new Exception("Time não participa desta partida.");

      var evento = new RodadaPartidaEvento(this.RodadaId, rodadaTimeId, participanteId, tipo);

      _eventos.Add(evento);
    }
  }

}
