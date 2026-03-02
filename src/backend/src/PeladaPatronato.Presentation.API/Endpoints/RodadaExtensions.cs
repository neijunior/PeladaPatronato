using Microsoft.AspNetCore.Mvc;
using PeladaPatronato.Application.Estatistica;
using PeladaPatronato.Application.Rodada;
using PeladaPatronato.Infra.CrossCutting.Request.Rodada;

namespace PeladaPatronato.Presentation.API.Endpoints
{
  public static class RodadaExtensions
  {
    public static WebApplication MapRodadaEndpoints(this WebApplication app)
    {
      var grupo = app.MapGroup("/rodada")
                     .WithTags("Rodada")
                     .RequireAuthorization();

      grupo.MapPost("/listar", async (IRodadaApplication rodadaApp, [FromBody] ConsultarRodadaRequest request) =>
      {
        try
        {

          var lista = await rodadaApp.Listar(request);
          return Results.Ok(lista.OrderBy(o => o.DataHora).ToList());
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

      grupo.MapPost("/", async (IRodadaApplication rodadaApp, [FromBody] CriarRodadaRequest request) =>
      {
        try
        {

          var id = await rodadaApp.CriarRodada(request);
          return Results.Ok(id);
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

      grupo.MapPost("/criarTimes", async (IRodadaApplication rodadaApp, [FromBody] CriarTimesRequest request) =>
      {
        try
        {

          await rodadaApp.CriarTimes(request);
          return Results.Ok();
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

      grupo.MapPost("/{rodadaId:guid}/partidas/gerar", async (IRodadaApplication rodadaApp, Guid rodadaId) =>
      {
        try
        {

          await rodadaApp.GerarPartidas(rodadaId);
          return Results.Ok();
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

      grupo.MapPost("/eventos/salvar", async (IRodadaApplication rodadaApp, SalvarEventosRequest request) =>
      {
        try
        {

          await rodadaApp.SalvarEventos(request);
          return Results.Ok();
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
