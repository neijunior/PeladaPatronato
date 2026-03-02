namespace PeladaPatronato.Presentation.API.Endpoints
{
  public static class EndpointExtensions
  {
    public static void MapEndpoints(this WebApplication app)
    {
      app.MapAuthEndpoints()
         .MapParticipanteEndpoints()
         .MapEstatisticaEndpoints()
         .MapLookupEndpoints()
         .MapRodadaEndpoints();
    }
  }
}
