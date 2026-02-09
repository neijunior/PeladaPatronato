using static PeladaPatronato.Domain.Enums;

namespace PeladaPatronato.Domain.Entidades
{
  public class RodadaParticipante
  {
    public Guid Id { get; private set; }
    public Guid RodadaTimeId { get; private set; }
    public Guid ParticipanteId { get; private set; }
    public eCategoriaPosicao CategoriaPosicao { get; private set; }

    private readonly List<RodadaEvento> _eventos = new();
    public IReadOnlyCollection<RodadaEvento> Eventos => _eventos;

    protected RodadaParticipante() { }

    internal RodadaParticipante(Guid rodadaTimeId, Guid participanteId, eCategoriaPosicao categoriaPosicao)
    {
      Id = Guid.NewGuid();
      RodadaTimeId = rodadaTimeId;
      ParticipanteId = participanteId;
      CategoriaPosicao = categoriaPosicao;
    }

    public void RegistrarEvento(eTipoEvento tipo, int? minuto = null)
    {
      _eventos.Add(new RodadaEvento(Id, tipo, minuto));
    }
  }

}
