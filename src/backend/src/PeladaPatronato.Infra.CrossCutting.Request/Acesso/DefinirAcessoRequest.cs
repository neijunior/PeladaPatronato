namespace PeladaPatronato.Infra.CrossCutting.Request.Acesso
{
  public class DefinirAcessoRequest
  {
    public Guid ParticipanteId { get; set; }
    public string Senha { get; set; } = string.Empty;
    public PerfilAcesso Perfil { get; set; }
  }

  public enum PerfilAcesso
  {
    Administrador = 1,
    Organizador = 2,
    Jogador = 3
  }
}
