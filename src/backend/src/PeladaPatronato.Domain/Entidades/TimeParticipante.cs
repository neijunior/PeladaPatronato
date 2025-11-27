namespace PeladaPatronato.Domain.Entidades
{
  public class TimeParticipante
  {
    public Guid Id { get; set; }
    public Guid TimeId { get; set; }
    public Guid ParticipanteId { get; set; }

    public TimeParticipante()
    {
      
    }
  }
}
