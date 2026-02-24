using PeladaPatronato.Infra.CrossCutting.Data;

namespace PeladaPatronato.Domain.Entidades
{
  public class LegadoTotalEstatistica : Entity
  {
    public LegadoTotalEstatistica() { }
    public string Periodo { get; private set; } = null!;
    public Guid ParticipanteId { get; private set; }
    public int TotalPartidas { get; private set; }
    public int TotalGols { get; private set; }
    public int TotalAssistencias { get; private set; }
    //public decimal MediaGols { get; private set; }
    //public decimal MediaAssistencias { get; private set; }
    public virtual Participante? Participante { get; private set; }
    public LegadoTotalEstatistica(string periodo, Guid participanteId, int totalPartidas, int totalGols, int totalAssistencias)
    {
      Periodo = periodo;
      ParticipanteId = participanteId;
      TotalPartidas = totalPartidas;
      TotalGols = totalGols;
      TotalAssistencias = totalAssistencias;
      //MediaGols = totalPartidas > 0 ? (decimal)totalGols / totalPartidas : 0;
      //MediaAssistencias = totalPartidas > 0 ? (decimal)totalAssistencias / totalPartidas : 0;
    }    
  }
}
