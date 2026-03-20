using Microsoft.AspNetCore.Mvc;
using PeladaPatronato.Application.Estatistica;
using PeladaPatronato.Application.Rodada;
using PeladaPatronato.Domain.Entidades;
using PeladaPatronato.Infra.CrossCutting.Request.Rodada;

namespace PeladaPatronato.Presentation.API.Endpoints
{
  public static class RodadaExtensions
  {
    public static WebApplication MapRodadaEndpoints(this WebApplication app)
    {
      var grupo = app.MapGroup("/rodadas")
                     .WithTags("Rodada")
                     .RequireAuthorization();

      grupo.MapGet("/{rodadaId:guid}", async (IRodadaApplication rodadaApp, Guid rodadaId) =>
      {
        try
        {
          var rodada = await rodadaApp.ObterPorId(rodadaId);

          return (rodada == null) ? Results.NotFound() : Results.Ok(rodada);
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

      grupo.MapPost("/pesquisar", async (IRodadaApplication rodadaApp, [FromBody] ConsultarRodadaRequest request) =>
      {
        try
        {

          var lista = await rodadaApp.Listar(request);
          return Results.Ok(lista);
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

      grupo.MapPost("/{rodadaId:guid}/times", async (IRodadaApplication rodadaApp, Guid rodadaId, [FromBody] CriarTimesRequest request) =>
      {
        try
        {
          await rodadaApp.CriarTimes(rodadaId, request);
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

      grupo.MapPost("/{rodadaId}/partidas", async (IRodadaApplication rodadaApp, Guid rodadaId) =>
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

      grupo.MapPost("/{rodadaId}/partida", async (IRodadaApplication rodadaApp, Guid rodadaId, [FromBody] CriarPartidaRequest request) =>
      {
        try
        {
          await rodadaApp.CriarPartida(rodadaId, request);

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

      grupo.MapGet("/{rodadaId:guid}/partidas", async (IRodadaApplication rodadaApp, Guid rodadaId) =>
      {
        try
        {
          var rodada = await rodadaApp.ListarPartidas(rodadaId);

          return (rodada == null) ? Results.NotFound() : Results.Ok(rodada);
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

      grupo.MapPost("/{rodadaId:guid}/partidas/{partidaId:guid}/eventos", async (IRodadaApplication rodadaApp, Guid rodadaId, Guid partidaId, SalvarEventosRequest request) =>
      {
        try
        {

          await rodadaApp.SalvarEventos(rodadaId, partidaId, request);
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

      grupo.MapPost("/rodadas/{rodadaId}/participantes", async (Guid rodadaId, AdicionarParticipanteRequest request, IRodadaApplication app) =>
      {
        try
        {
          await app.AdicionarParticipante(rodadaId, request);

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

      grupo.MapDelete("/rodadas/{rodadaId}/participantes/{participanteId}", async (Guid rodadaId, Guid participanteId, IRodadaApplication app) =>
      {
        try
        {
          await app.RemoverParticipante(rodadaId, participanteId);

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

      grupo.MapPatch("/rodadas/{rodadaId:guid}/participantes/{participanteId:guid}/pagamento", async (Guid rodadaId, Guid participanteId, [FromBody] bool pago, IRodadaApplication app) =>
       {
         try
         {
           await app.AtualizarPagamento(rodadaId, participanteId, pago);

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
