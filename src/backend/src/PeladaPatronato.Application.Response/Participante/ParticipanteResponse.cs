namespace PeladaPatronato.Application.Response.Participante
{
    public class ParticipanteResponse
    {
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Apelido { get; set; }
    public string Telefone { get; set; }
    //public ePosicao PosicaoPreferida { get; set; }
    public bool Ativo { get; set; }
    public DateTime DataCadastro { get; set; }
  }
}
