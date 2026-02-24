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
    public string? NomeUsuario { get; private set; }
    public virtual Posicao? Posicao { get; private set; }
    public bool PossuiAcesso { get; private set; }
    public string? Email { get; private set; }
    public string? SenhaHash { get; private set; }
    public PerfilAcesso? Perfil { get; private set; }

    public Participante(string nome, string? apelido, string? telefone, ePosicao? posicaoPreferida)
    {
      this.Nome = nome;
      this.Apelido = apelido;
      this.Telefone = telefone;
      this.IdPosicaoPreferida = posicaoPreferida.HasValue ? (int)posicaoPreferida : null;
      this.Ativo = true;
      this.DataCadastro = DateTime.Now;
      this.NomeUsuario = nomeUsuario;
    }
    public void Atualizar(string nome, string? apelido, string? telefone, ePosicao? posicaoPreferida, bool ativo, string? email)
    {
      Nome = nome;
      Apelido = apelido;
      Telefone = telefone;
      IdPosicaoPreferida = posicaoPreferida.HasValue ? (int)posicaoPreferida : null;
      Ativo = ativo;
      Email = email;
    }
    public void Inativar() => this.Ativo = false;
    public void DefinirAcesso(string senhaHash, PerfilAcesso perfil)
    {
      PossuiAcesso = true;
      SenhaHash = senhaHash;
      Perfil = perfil;
      PossuiAcesso = true;
    }

    public void RemoverAcesso()
    {
      PossuiAcesso = false;
      SenhaHash = null;
      Perfil = null;
    }
  }
  public enum PerfilAcesso
  {
    Administrador = 1,
    Organizador = 2,
    Jogador = 3
  }
}
