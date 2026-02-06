using Microsoft.AspNetCore.Mvc;
using PeladaPatronato.Application.Generico;

namespace PeladaPatronato.Presentation.API.Endpoints
{
  public static class LookupExtension
  {
    const string _nomeRota = "lookup/";
    public static WebApplication MapLookupEndpoints(this WebApplication app)
    {
      app.MapPost($"/{_nomeRota}posicao", async (IGenericoApplication app) =>
      {
        try
        {
          return Results.Ok(await app.ListarPosicoes());

        }
        catch (Exception ex)
        {
          return Results.BadRequest(ex.Message);
        }
      }).WithTags("LookUp");

      return app;
    }
  }
}
