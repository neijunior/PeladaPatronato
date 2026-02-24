using PeladaPatronato.Infra.CrossCutting.Request.Acesso;
using PeladaPatronato.Infra.CrossCutting.Response.Acesso;

namespace PeladaPatronato.Application.Acesso
{
  public interface IAutenticacaoApplication
  {
    Task<LoginResponse> Login(LoginRequest request);
    Task DefinirAcesso(DefinirAcessoRequest request);
  }
}
