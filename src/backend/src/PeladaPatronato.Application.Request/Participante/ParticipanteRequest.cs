using static PeladaPatronato.Domain.Entidades.Participante;
using static PeladaPatronato.Domain.Enums;

namespace PeladaPatronato.Application.Request.Participante
{
  public class ParticipanteRequest
  {
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string? Apelido { get; set; }
    public string? Telefone { get; set; }
    public ePosicao? PosicaoPreferida { get; set; }
    public bool Ativo { get; set; }
  }
}
