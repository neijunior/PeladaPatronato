using PeladaPatronato.Domain.Entidades;
using PeladaPatronato.Domain.Interfaces;

namespace PeladaPatronato.Infra.Data.EntityFrameworkCore
{
  public class ParticipanteRepository : IParticipanteRepository
  {
    public async Task<Participante> Consultar(Guid Id)
    {
      throw new NotImplementedException();
    }

    public async Task<Participante> Inativar()
    {
      throw new NotImplementedException();
    }

    public async Task<IEnumerable<Participante>> Listar()
    {
      throw new NotImplementedException();
    }

    public async Task<Participante> Salvar()
    {
      throw new NotImplementedException();
    }
  }
}
