using PeladaPatronato.Infra.CrossCutting.Data;

namespace PeladaPatronato.Domain.Entidades
{
  public class Participante : Entity
  {

    protected Participante() { }
    
    public string Nome { get; private set; } = string.Empty;
    public string? Apelido { get; private set; }
    public string? Telefone { get; private set; }
    public int? IdPosicaoPreferida { get; private set; }
    public bool Ativo { get; private set; }
    public DateTime DataCadastro { get; private set; }
    public virtual Posicao? Posicao { get; private set; }
    public Participante(string nome, string? apelido, string? telefone, ePosicao? posicaoPreferida)
    {
      this.Nome = nome;
      this.Apelido = apelido;
      this.Telefone = telefone;
      this.IdPosicaoPreferida = posicaoPreferida.HasValue ? (int)posicaoPreferida : null;
      this.Ativo = true;
      this.DataCadastro = DateTime.Now;
    }
    public void Atualizar(string nome, string? apelido, string? telefone, ePosicao? posicaoPreferida, bool ativo)
    {
      Nome = nome;
      Apelido = apelido;
      Telefone = telefone;
      IdPosicaoPreferida = posicaoPreferida.HasValue ? (int)posicaoPreferida : null;
      Ativo = ativo;
    }
    public void Inativar() => this.Ativo = false;
  }
}
