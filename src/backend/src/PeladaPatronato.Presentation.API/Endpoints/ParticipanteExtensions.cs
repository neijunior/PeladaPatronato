using Microsoft.AspNetCore.Mvc;
using PeladaPatronato.Application.Acesso;
using PeladaPatronato.Application.Participante;
using PeladaPatronato.Infra.CrossCutting.Request.Acesso;
using PeladaPatronato.Infra.CrossCutting.Request.Participante;
using PeladaPatronato.Infra.CrossCutting.Response;
using PeladaPatronato.Infra.CrossCutting.Response.Participante;

namespace PeladaPatronato.Presentation.API.Endpoints
{
  public static class ParticipanteExtensions
  {
    const string _nomeRota = "participante/";
    public static WebApplication MapParticipanteEndpoints(this WebApplication app)
    {
      var grupo = app.MapGroup("/participante")
                       .WithTags("Participante")
                       .RequireAuthorization(); // exige autenticação geral

      grupo.MapPost($"/salvar", async (IParticipanteApplication participanteApp, Guid Responsavel, [FromBody] ParticipanteRequest participante) =>
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

      }).RequireAuthorization("Todos");

      grupo.MapDelete($"/{{id}}/inativar", async (Guid id, IParticipanteApplication participanteApp) =>
      {
        await participanteApp.Inativar(id);
        return Results.NoContent();
      }).RequireAuthorization("SomenteAdministrador");


      grupo.MapPost($"/listar", async (IParticipanteApplication participanteApp, [FromBody] ConsultaParticipanteRequest paramConsulta) =>
      {
        try
        {
          return Results.Ok(await participanteApp.Listar(paramConsulta));

        }
        catch (Exception ex)
        {
          return Results.BadRequest(ex.Message);
        }
      }).RequireAuthorization("Todos");

      grupo.MapGet($"/consultar", async (IParticipanteApplication participanteApp, Guid Id) =>
      {
        try
        {
          return Results.Ok(await participanteApp.Consultar(Id));

        }
        catch (Exception ex)
        {
          return Results.BadRequest(ex.Message);
        }
      }).RequireAuthorization("Todos");

      grupo.MapPost("/definir-acesso", async (IAutenticacaoApplication app, [FromBody] DefinirAcessoRequest request) =>
      {
        try
        {
          await app.DefinirAcesso(request);

          return Results.Ok(new
          {
            sucesso = true,
            mensagem = "Acesso definido com sucesso"
          });
        }
        catch (Exception ex)
        {
          return Results.BadRequest(new
          {
            sucesso = false,
            mensagem = ex.Message
          });
        }
      }).RequireAuthorization("SomenteAdministrador");

      return app;
    }
  }
}
