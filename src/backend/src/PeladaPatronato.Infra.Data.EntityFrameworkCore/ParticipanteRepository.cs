using Microsoft.EntityFrameworkCore;
using PeladaPatronato.Domain.Entidades;
using PeladaPatronato.Domain.Interfaces;

namespace PeladaPatronato.Infra.Data.EntityFrameworkCore
{
  public class ParticipanteRepository : IParticipanteRepository
  {
    private readonly PeladaPatronatoDbContext _context;

    public ParticipanteRepository(PeladaPatronatoDbContext context)
    {
      _context = context ?? throw new ArgumentNullException(nameof(context));
    }

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

    public async Task<Participante> Salvar(Participante participante)
    {
      if (participante is null)
      {
        throw new ArgumentNullException(nameof(participante));
      }

      var dbSet = _context.Set<Participante>();

      if (participante.Id == Guid.Empty)
      {
        participante.Id = Guid.NewGuid();
        await dbSet.AddAsync(participante).ConfigureAwait(false);
      }
      else
      {
        dbSet.Update(participante);
      }

      await _context.SaveChangesAsync().ConfigureAwait(false);

      return participante;
    }
  }
}
