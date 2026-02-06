using Microsoft.AspNetCore.Mvc;
using PeladaPatronato.Application.Participante;
using PeladaPatronato.Application.Request.Participante;
using PeladaPatronato.Application.Response;
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
          var result = await participanteApp.Salvar(participante);
          return Results.Ok(ApiResponse<ParticipanteResponse>.Ok(result, "Participante salvo com sucesso"));
        }
        catch (Exception ex)
        {
          return Results.BadRequest(ApiResponse<object>.Fail(ex.Message));
        }

      }).WithTags("Participante");

      //app.MapDelete($"/{_nomeRota}/{{id}}/inativar", async (Guid id, IParticipanteApplication participanteApp) =>
      //{
      //  await participanteApp.Inativar(id);
      //  return Results.NoContent();
      //}).WithTags("Participante");


      app.MapPost($"/{_nomeRota}listar", async (IParticipanteApplication participanteApp, [FromBody] ConsultaParticipanteRequest paramConsulta) =>
      {
        try
        {
          return Results.Ok(await participanteApp.Listar(paramConsulta));

        }
        catch (Exception ex)
        {
          return Results.BadRequest(ex.Message);
        }
      }).WithTags("Participante");

      return app;
    }
  }
}
