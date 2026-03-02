using Microsoft.EntityFrameworkCore;
using PeladaPatronato.Domain.Entidades;
using PeladaPatronato.Domain.Interfaces;
using PeladaPatronato.Infra.Data.EntityFrameworkCore.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeladaPatronato.Infra.Data.EntityFrameworkCore.Repositories
{
  public class RodadaRepository : IRodadaRepository
  {
    protected readonly PeladaPatronatoDbContext _context;
    public RodadaRepository(PeladaPatronatoDbContext context) 
    {
      _context = context;
    }
    public async Task<Rodada?> ObterPorId(Guid id)
    {
      return await _context.Rodada.Include(r => r.Times).ThenInclude(t => t.Participantes)
                                  .Include(r => r.Partidas).ThenInclude(p => p.Eventos)
          .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task CriarRodada(Rodada rodada)
    {
      await _context.Rodada.AddAsync(rodada);
    }

    public void Atualizar(Rodada rodada)
    {
      _context.Rodada.Update(rodada);
    }

    public async Task<ICollection<Rodada>> Listar(DateTime dataInicio, DateTime? dataFim)
    {
      return await _context.Rodada.Where(w => w.DataHora >= dataInicio && (dataFim == null || w.DataHora <= dataFim)).ToListAsync(); 
    }
  }
}
