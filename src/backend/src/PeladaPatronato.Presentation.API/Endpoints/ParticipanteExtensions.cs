using Microsoft.AspNetCore.Mvc;
using PeladaPatronato.Application.Participante;
using PeladaPatronato.Application.Request.Participante;
using PeladaPatronato.Application.Response.Participante;

namespace PeladaPatronato.Presentation.API.Endpoints
{
  public static class ParticipanteExtensions
  {
    const string _nomeRota = "participante/";
    public static WebApplication MapParticipanteEndpoints(this WebApplication app)
    {
      app.MapPost($"/{_nomeRota}salvar", async (IParticipanteApplication participanteApp, [FromBody] ParticipanteRequest participante) =>
      {
        try
        {
          return Results.Ok(await participanteApp.Salvar(participante));
        }
        catch (Exception ex)
        {
          return Results.BadRequest(ex.Message);
        }

      }).WithTags("Produto");
      app.MapDelete($"/{_nomeRota}excluir", () => "Hello World!").WithTags("Produto");
      //app.MapPost($"/{_nomeRota}listar", async (IParticipanteApplication participanteApp, [FromBody] ConsultaProdutoRequest paramConsulta) =>
      //{
      //  try
      //  {
      //    return Results.Ok(await produtoApp.Listar(paramConsulta));

      //  }
      //  catch (Exception ex)
      //  {
      //    return Results.BadRequest(ex.Message);
      //  }
      //}).WithTags("Produto");

      return app;
    }
  }
}
