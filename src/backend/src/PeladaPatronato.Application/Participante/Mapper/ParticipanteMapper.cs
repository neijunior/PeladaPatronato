using PeladaPatronato.Application.Response.Participante;

namespace PeladaPatronato.Application.Participante
{
  public static class ParticipanteMapper
  {
    public static ParticipanteResponse ToResponse(this Domain.Entidades.Participante participante)
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
        DataCadastro = participante.DataCadastro
      };
    }

    public static IEnumerable<ParticipanteResponse> ToResponse(this IEnumerable<Domain.Entidades.Participante> participantes)
    {
      return participantes.Select(p => p.ToResponse());
    }
  }
}
