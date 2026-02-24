namespace PeladaPatronato.Infra.CrossCutting.Request.Acesso
{
  public class LoginRequest
  {
    public string NomeUsuario { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
  }
}
