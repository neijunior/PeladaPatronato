using PeladaPatronato.Infra.CrossCutting.Data;

namespace PeladaPatronato.Domain.Entidades
{
  public class RodadaTimeParticipante : Entity
  {
    public Guid RodadaTimeId { get; private set; }
    public Guid RodadaParticipanteId { get; private set; }
    //public eCategoriaPosicao CategoriaPosicao { get; private set; }

    protected RodadaTimeParticipante() { }

    public RodadaTimeParticipante(Guid rodadaTimeId, Guid rodadaParticipanteId)        //eCategoriaPosicao categoriaPosicao)
    {
      RodadaTimeId = rodadaTimeId;
      RodadaParticipanteId = rodadaParticipanteId;
      //CategoriaPosicao = categoriaPosicao;
    }
  }
}