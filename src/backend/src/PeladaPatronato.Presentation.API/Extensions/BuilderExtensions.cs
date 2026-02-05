using PeladaPatronato.Infra.CrossCutting.IoC;

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
      services.AddSwaggerGen();      

      //var jwtSettings = configuration.GetSection("Jwt");

      //services.AddAuthentication("Bearer")
      //  .AddJwtBearer("Bearer", options =>
      //  {
      //    options.TokenValidationParameters = new TokenValidationParameters
      //    {
      //      ValidateIssuer = true,
      //      ValidateAudience = true,
      //      ValidateLifetime = true,
      //      ValidateIssuerSigningKey = true,
      //      ValidIssuer = jwtSettings["Issuer"],
      //      ValidAudience = jwtSettings["Audience"],
      //      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]))
      //    };
      //  });

      //services.Configure<JwtSettings>(configuration.GetSection("Jwt"));

      //services.AddAutoMapper(typeof(MappingEntidade).Assembly);
      services.Register(configuration);
    }

  }
}
