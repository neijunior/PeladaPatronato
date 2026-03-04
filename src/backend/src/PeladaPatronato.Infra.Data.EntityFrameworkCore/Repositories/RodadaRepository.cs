using Azure.Core;
using Microsoft.EntityFrameworkCore;
using PeladaPatronato.Domain.Entidades;
using PeladaPatronato.Domain.Interfaces;
using PeladaPatronato.Infra.Data.EntityFrameworkCore.Contexts;

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
                                  .Include(r => r.Participantes).ThenInclude(p => p.Participante)
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

    public async Task AdicionarParticipante(Guid rodadaId, Guid participanteId, bool diarista)
    {
      try
      {
        var rodada = await ObterPorId(rodadaId);

        if (rodada == null)
          throw new Exception("Rodada não encontrada.");

        if (rodada.Status != StatusRodada.Criada)
          throw new Exception("Rodada não está aberta.");

        if (rodada.Participantes.Any(x => x.ParticipanteId == participanteId))
          throw new Exception("Participante já adicionado.");

        RodadaParticipante rp = new RodadaParticipante(rodada.Id, participanteId, diarista);

        _context.Add(rp);
      }
      catch (Exception)
      {

        throw;
      }
    }

    public async Task RemoverParticipante(Guid rodadaId, Guid participanteId)
    {
      try
      {
        var rodada = await ObterPorId(rodadaId);

        if (rodada == null)
          throw new Exception("Rodada não encontrada.");

        if (rodada.Status != StatusRodada.Criada)
          throw new Exception("Rodada não está aberta.");

        var participante = rodada.Participantes
            .FirstOrDefault(x => x.ParticipanteId == participanteId);

        if (participante == null)
          throw new Exception("Participante não encontrado na rodada.");

        _context.Remove(participante);
      }
      catch (Exception)
      {

        throw;
      }
    }

    public async Task<ICollection<Rodada>> Listar(DateTime dataInicio, DateTime? dataFim)
    {
      return await _context.Rodada.Where(w => w.DataHora >= dataInicio && (dataFim == null || w.DataHora <= dataFim)).ToListAsync();
    }
  }
}
