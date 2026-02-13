using Microsoft.IdentityModel.Tokens;
using PeladaPatronato.Infra.CrossCutting.IoC;
using System.Text;

namespace PeladaPatronato.Presentation.API.Extensions
{
  public static class BuilderExtensions
  {
    public static void AddArchitectures(this WebApplicationBuilder builder)
    {
      builder.Services.AddServices(builder.Configuration);
    }

    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddCors(opt =>
      {
        opt.AddDefaultPolicy(policy =>
        {
          policy.WithOrigins("http://localhost:3000", "https://peladadopatronato.neijunior.dev.br/")  // frontend
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
      });

      services.AddEndpointsApiExplorer();
      services.AddSwaggerGen(options =>
      {
        options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
        {
          Name = "Authorization",
          Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
          Scheme = "bearer",
          BearerFormat = "JWT",
          In = Microsoft.OpenApi.Models.ParameterLocation.Header,
          Description = "Digite: Bearer {seu token}"
        });

        options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
        {
            {
                new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Reference = new Microsoft.OpenApi.Models.OpenApiReference
                    {
                        Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
        });
      });

      var jwtSettings = configuration.GetSection("Jwt");

      services.AddAuthentication("Bearer")
        .AddJwtBearer("Bearer", options =>
        {
          options.TokenValidationParameters = new TokenValidationParameters
          {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]))
          };
        });

      //services.Configure<JwtSettings>(configuration.GetSection("Jwt"));

      //services.AddAutoMapper(typeof(MappingEntidade).Assembly);
      services.Register(configuration);
    }

  }
}
