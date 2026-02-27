using PeladaPatronato.Infra.CrossCutting.Response.Participante;

namespace PeladaPatronato.Infra.CrossCutting.Response.Estatistica
{
  public class EstatisticaResponse
  {
    public Guid ParticipanteId { get; set; }
    public string? Periodo { get; set; }
    public DateTime? DataJogo { get; set; }
    public int TotalPartidas { get; set; }
    public int TotalGols  { get; set; }
    public int TotalAssistencias { get; set; }
    public decimal MediaGols => TotalPartidas == 0 ? 0 : Math.Round((decimal)TotalGols / TotalPartidas, 2);
    public decimal MediaAssistencias => TotalPartidas == 0 ? 0 : Math.Round((decimal)TotalGols / TotalPartidas, 2);
    public ParticipanteResponse Participante { get; set; } = new ParticipanteResponse();
  }
}
