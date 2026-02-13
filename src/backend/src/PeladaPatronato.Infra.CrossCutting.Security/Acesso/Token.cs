using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PeladaPatronato.Domain.Entidades;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PeladaPatronato.Infra.CrossCutting.Security.Acesso
{
  public class Token : IToken
  {
    private readonly IConfiguration _configuration;
    public Token(IConfiguration configuration)
    {
      _configuration = configuration;
    }
    public string GerarToken(Participante participante)
    {
      var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, participante.Id.ToString()),
            new Claim(ClaimTypes.Name, participante.Nome),
            new Claim(ClaimTypes.Role, participante.Perfil!.ToString())
        };

      var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

      var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

      var token = new JwtSecurityToken(issuer: _configuration["Jwt:Issuer"],
                                       audience: _configuration["Jwt:Audience"],
                                       claims: claims,
                                       expires: DateTime.UtcNow.AddHours(3),
                                       signingCredentials: credenciais);

      return new JwtSecurityTokenHandler().WriteToken(token);
    }
  }
}
