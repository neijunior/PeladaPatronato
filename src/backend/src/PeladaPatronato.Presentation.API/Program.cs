using PeladaPatronato.Presentation.API.Endpoints;
using PeladaPatronato.Presentation.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.AddArchitectures();

builder.Services.AddAuthorization(options =>
{
  options.AddPolicy("SomenteAdministrador", policy =>
      policy.RequireRole("Administrador"));

  options.AddPolicy("SomenteOrganizador", policy =>
      policy.RequireRole("Organizador"));

  options.AddPolicy("SomenteJogador", policy =>
      policy.RequireRole("Jogador"));

  options.AddPolicy("Todos", policy =>
      policy.RequireRole("Administrador", "Organizador", "Jogador"));
});

var app = builder.Build();

app.MapEndpoints();

app.UseArchitectures();

app.Run();

