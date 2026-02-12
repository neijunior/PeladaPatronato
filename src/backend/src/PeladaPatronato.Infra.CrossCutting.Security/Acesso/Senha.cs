namespace PeladaPatronato.Infra.CrossCutting.Security.Acesso
{
  public static class Senha
  {
    public static bool VerificarSenha(string senha, string senhaHash)
    {
      return BCrypt.Net.BCrypt.Verify(senha, senhaHash);
    }
  }
}
