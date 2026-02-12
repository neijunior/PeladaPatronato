using System;
using System.Security.Cryptography;
using System.Text;

namespace PeladaPatronato.Infra.CrossCutting.Foundation
{
  public class Criptografia
  {
    public static string GerarHashVotante(Guid jogadorVotanteId, Guid partidaId, string chaveSecreta)
    {
      var chaveBytes = Encoding.UTF8.GetBytes(chaveSecreta);

      var hmac = new HMACSHA256(chaveBytes);

      var dados = $"{jogadorVotanteId}{partidaId}";
      var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dados));

      return Convert.ToBase64String(hash);
    }
  }
}
