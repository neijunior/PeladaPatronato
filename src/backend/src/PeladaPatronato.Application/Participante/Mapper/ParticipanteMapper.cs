using PeladaPatronato.Application.Request.Participante;
using PeladaPatronato.Application.Response;
using PeladaPatronato.Application.Response.Participante;

namespace PeladaPatronato.Application.Participante
{
  public static class ParticipanteMapper
  {
    public static ParticipanteResponse? ToResponse(this Domain.Entidades.Participante participante)
    {
      if (participante == null)
        return null;

      return new ParticipanteResponse
      {
        Id = participante.Id,
        Nome = participante.Nome,
        Apelido = participante.Apelido,
        Telefone = participante.Telefone,
        Ativo = participante.Ativo,
        DataCadastro = participante.DataCadastro,
        PosicaoPreferida = participante.Posicao != null
          ? new PosicaoResponse
          {
            Id = participante.Posicao.Id,
            Nome = participante.Posicao.Nome
          }
          : null
      };
    }

    public static IEnumerable<ParticipanteResponse> ToResponse(this IEnumerable<Domain.Entidades.Participante> participantes)
    {
      return participantes.Select(p => p.ToResponse());
    }

    public static Domain.Entidades.Participante ToEntity(this ParticipanteRequest participante)
    {
      if (participante == null)
        throw new ArgumentNullException(nameof(participante));

      return new Domain.Entidades.Participante(
          participante.Nome,
          participante.Apelido,
          participante.Telefone,
          participante.PosicaoPreferida,
          participante.NomeUsuario);
    }
  }
}
