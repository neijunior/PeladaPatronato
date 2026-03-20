namespace PeladaPatronato.Infra.CrossCutting.Response.Rodada
{
  public class RodadaPartidaResponse
  {
    public Guid Id { get; set; }
    public Guid RodadaId { get; set; }
    public Guid RodadaTimeAId { get; set; }
    public Guid RodadaTimeBId { get; set; }
    public int Ordem { get; set; }
    public Guid? TimeComPosseInicialId { get; set; }
    public DateTime? DataHora { get; set; }
  }
}
