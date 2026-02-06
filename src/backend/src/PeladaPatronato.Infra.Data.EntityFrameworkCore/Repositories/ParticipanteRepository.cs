using PeladaPatronato.Domain.Entidades;
using PeladaPatronato.Domain.Interfaces;
using PeladaPatronato.Infra.Data.EntityFrameworkCore.Contexts;

namespace PeladaPatronato.Infra.Data.EntityFrameworkCore.Repositories
{
  public class ParticipanteRepository : RepositoryBase<Participante>, IParticipanteRepository
  {
    public ParticipanteRepository(PeladaPatronatoDbContext context) : base(context)
    {
    }
  }
}
