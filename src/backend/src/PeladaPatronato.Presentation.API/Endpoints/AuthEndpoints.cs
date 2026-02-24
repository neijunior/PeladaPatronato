using Microsoft.AspNetCore.Mvc;
using PeladaPatronato.Application.Acesso;
using PeladaPatronato.Infra.CrossCutting.Request.Acesso;

namespace PeladaPatronato.Presentation.API.Endpoints
{
  public static class AuthEndpoints
  {
    public static WebApplication MapAuthEndpoints(this WebApplication app)
    {
      var grupo = app.MapGroup("/auth")
                     .WithTags("Autenticação");

      grupo.MapPost("/login", async (IAutenticacaoApplication autenticacao,
                 [FromBody] LoginRequest request) =>
          {
            try
            {
              var response = await autenticacao.Login(request);
              return Results.Ok(response);
            }
            catch (Exception ex)
            {
              return Results.BadRequest(new
              {
                sucesso = false,
                mensagem = ex.Message
              });
            }
          });

      return app;
    }
  }
}
