using PeladaPatronato.Presentation.API.Endpoints;
using PeladaPatronato.Presentation.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.AddArchitectures();

var app = builder.Build();

app.MapEndpoints();

app.UseArchitectures();

app.Run();

