using PeladaPatronato.Infra.CrossCutting.Data;

namespace PeladaPatronato.Domain.Entidades
{
  public class RodadaTime : Entity
  {
    public Guid RodadaId { get; private set; }
    public Guid TimeBaseId { get; private set; }

    public int Vitorias { get; private set; }
    public int Derrotas { get; private set; }
    public int Empates { get; private set; }
    public int GolsPro { get; private set; }
    public int GolsContra { get; private set; }
    public ICollection<RodadaTimeParticipante> Participantes { get; private set; } = new HashSet<RodadaTimeParticipante>();
    protected RodadaTime() { }

    public RodadaTime(Guid rodadaId, Guid timeBaseId)
    {
      RodadaId = rodadaId;
      TimeBaseId = timeBaseId;
    }

    public void AdicionarParticipante(RodadaTimeParticipante item)
    {
      this.Participantes??= new List<RodadaTimeParticipante>();
      this.Participantes.Add(item);
    }

    internal void RegistrarResultado(int golsPro, int golsContra)
    {
      GolsPro += golsPro;
      GolsContra += golsContra;

      if (golsPro > golsContra) Vitorias++;
      else if (golsPro < golsContra) Derrotas++;
      else Empates++;
    }
  }

}
