namespace PeladaPatronato.Infra.CrossCutting.Request.Participante
{
  public class ConsultaParticipanteRequest
  {
    public Guid? Id { get; set; }
    public int? IdPosicao { get; set; }
    public bool? Ativo { get; set; }
    public string? Nome { get; set; }
    public bool? ExibePosicao { get; set; }
    
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? OrderBy { get; set; }
    public string Direction { get; set; } = "asc";
  }
}
