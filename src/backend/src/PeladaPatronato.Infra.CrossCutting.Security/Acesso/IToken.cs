using PeladaPatronato.Domain.Entidades;

namespace PeladaPatronato.Infra.CrossCutting.Security.Acesso
{
  public interface IToken
  {
    string GerarToken(Participante participante);
  }
}
