using PeladaPatronato.Application.Request.Acesso;
using PeladaPatronato.Application.Response.Acesso;

namespace PeladaPatronato.Application.Acesso
{
  public interface IAutenticacaoApplication
  {
    Task<LoginResponse> Login(LoginRequest request);
    Task DefinirAcesso(DefinirAcessoRequest request);
  }
}
