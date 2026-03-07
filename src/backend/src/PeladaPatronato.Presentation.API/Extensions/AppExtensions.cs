namespace PeladaPatronato.Presentation.API.Extensions
{
  public static class AppExtensions
  {
    public static void UseArchitectures(this WebApplication app)
    {
      //if (app.Environment.IsDevelopment())
      //{
      app.UseAuthentication();
      app.UseAuthorization();

      app.UseSwagger();
      app.UseSwaggerUI();
      //app.UseSwaggerUI(c =>
      //{
      //  c.RoutePrefix = string.Empty;
      //  c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API V1");
      //});
      //}

      app.UseCors(x => x.AllowAnyMethod()
                        .AllowAnyHeader()
                        .SetIsOriginAllowed(origin => true)
                        .AllowCredentials());

      app.UseHttpsRedirection();
    }
  }
}
