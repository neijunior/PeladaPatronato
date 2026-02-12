using System;
using System.Security.Cryptography;
using System.Text;

namespace PeladaPatronato.Infra.CrossCutting.Foundation
{
  public static class Criptografia
  {
    public static string GerarHashVotante(Guid jogadorVotanteId, Guid partidaId, string chaveSecreta)
    {
      var chaveBytes = Encoding.UTF8.GetBytes(chaveSecreta);

      var hmac = new HMACSHA256(chaveBytes);

      var dados = $"{jogadorVotanteId}{partidaId}";
      var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dados));

      return Convert.ToBase64String(hash);
    }

    public static string GerarHash(string senha) => BCrypt.Net.BCrypt.HashPassword(senha);
    public static bool Verificar(string senha, string hash) => BCrypt.Net.BCrypt.Verify(senha, hash);
  }
}
