using Microsoft.AspNetCore.Mvc;
using PeladaPatronato.Application.Estatistica;
using PeladaPatronato.Infra.CrossCutting.Request.Estatistica;

namespace PeladaPatronato.Presentation.API.Endpoints
{
  public static class EstatisticaExtensions
  {
    public static WebApplication MapEstatisticaEndpoints(this WebApplication app)
    {
      var grupo = app.MapGroup("/estatistica")
                     .WithTags("Estatistica")
                     .RequireAuthorization(); 

      grupo.MapPost("/listar", async (IEstatisticaApplication estatistica, [FromBody] ConsultaEstatisticaRequest paramConsulta) =>
      {
        try
        {
          var response = await estatistica.Listar(paramConsulta);
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
