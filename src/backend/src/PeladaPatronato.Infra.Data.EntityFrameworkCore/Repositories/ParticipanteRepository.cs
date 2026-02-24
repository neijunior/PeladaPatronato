using Microsoft.EntityFrameworkCore;
using PeladaPatronato.Domain.Entidades;
using PeladaPatronato.Domain.Interfaces;
using PeladaPatronato.Infra.Data.EntityFrameworkCore.Contexts;

namespace PeladaPatronato.Infra.Data.EntityFrameworkCore.Repositories
{
  public class ParticipanteRepository : RepositoryBase<Participante>, IParticipanteRepository
  {
    protected readonly PeladaPatronatoDbContext _context;
    public ParticipanteRepository(PeladaPatronatoDbContext context) : base(context)
    {
      _context = context;
    }

    public async Task<Participante?> ObterPorNomeUsuario(string nomeUsuario)
    {
      return await _context.Participante.FirstOrDefaultAsync(w => w.NomeUsuario == nomeUsuario);
      
    }
  }
}
