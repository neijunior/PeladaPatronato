namespace PeladaPatronato.Infra.CrossCutting.Request.Participante
{
  public class ParticipanteRequest
  {
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string? Apelido { get; set; }
    public string? Telefone { get; set; }
    public ePosicao? PosicaoPreferida { get; set; }
    public bool Ativo { get; set; }
    public string? Email { get; set; }
    public string? NomeUsuario { get; set; }
  }

  public enum ePosicao
  {
    Goleiro = 1,
    Fixo = 2,
    Ala = 3,
    Pivo = 4
  }

  public enum eCategoriaPosicao
  {
    Goleiro = 1,
    Linha = 2
  }
}
