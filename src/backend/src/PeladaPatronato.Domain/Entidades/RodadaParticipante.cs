using PeladaPatronato.Infra.CrossCutting.Data;

namespace PeladaPatronato.Domain.Entidades
{
  public class RodadaParticipante : Entity
  {
    public Guid RodadaId { get; private set; }
    public Guid ParticipanteId { get; private set; }
    public DateTime? DataConfirmacao { get; private set; }
    public bool? Diarista { get; private set; }
    public RodadaParticipante()
    {
        
    }

    public RodadaParticipante(Guid rodadaId, Guid participanteId, bool? diarista)
    {
      RodadaId = rodadaId;
      ParticipanteId = participanteId;
      Diarista = diarista;
      DataConfirmacao = null;
    }
  }
}