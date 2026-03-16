namespace PeladaPatronato.Infra.CrossCutting.Response.Rodada
{
  public class RodadaResponse
  {
    public Guid Id { get; set; }
    public DateTime DataHora { get; set; }
    public decimal ValorDiarista { get; set; }
    public string? Observacao { get; set; }
    public string? DescricaoStatus { get; set; }
    public ICollection<RodadaParticipanteResponse> participantes { get; set; } = new List<RodadaParticipanteResponse>();
    public ICollection<RodadaTimeParticipanteResponse> times { get; set; } = new List<RodadaTimeParticipanteResponse>();
  }
}
