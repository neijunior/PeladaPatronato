using PeladaPatronato.Infra.CrossCutting.Data;

namespace PeladaPatronato.Domain.Entidades
{
  public class Rodada : IAggregateRoot
  {
    public Guid Id { get; private set; }
    public DateTime DataHora { get; private set; }
    public decimal ValorDiarista { get; private set; }
    public string? Observacao { get; private set; }

    private readonly List<RodadaTime> _times = new();
    public IReadOnlyCollection<RodadaTime> Times => _times;

    protected Rodada() { } // EF

    public Rodada(DateTime dataHora, decimal valorDiarista, string? observacao)
    {
      Id = Guid.NewGuid();
      DataHora = dataHora;
      ValorDiarista = valorDiarista;
      Observacao = observacao;
    }

    public RodadaTime AdicionarTime(Guid timeId)
    {
      var rodadaTime = new RodadaTime(Id, timeId);
      _times.Add(rodadaTime);
      return rodadaTime;
    }

  }
}
