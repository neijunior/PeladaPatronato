namespace PeladaPatronato.Domain.Entidades
{
  public class Participante : IAggregateRoot
  {
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string Apelido { get; private set; }
    public string Telefone { get; private set; }
    public ePosicao PosicaoPreferida { get; private set; }
    public bool Ativo { get; private set; }
    public DateTime DataCadastro { get; private set; }

    public Participante(string id, string nome, string apelido, string telefone, ePosicao posicaoPreferida, bool ativo)
    {
      this.Id = Guid.Parse(id);
      this.Nome = nome;
      this.Apelido = apelido;
      this.Telefone = telefone;
      this.PosicaoPreferida = posicaoPreferida;
      this.Ativo = ativo;
      this.DataCadastro = DateTime.Now;
    }

    public void Inativar(Guid Id) => this.Ativo = false;

    public enum ePosicao
    {
      Goleiro = 1,
      Fixo = 2,
      Ala = 3,
      Pivo = 4
    }
  }
}
