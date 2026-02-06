namespace PeladaPatronato.Application.Request.Participante
{
  public class ConsultaParticipanteRequest
  {
    public Guid? Id { get; set; }
    public int? IdPosicao { get; set; }
    public bool? Ativo { get; set; }
    public string? Nome { get; set; }
    public bool? ExibePosicao { get; set; }
  }
}
