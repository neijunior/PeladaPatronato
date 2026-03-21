using Azure.Core;
using Microsoft.EntityFrameworkCore;
using PeladaPatronato.Domain.Entidades;
using PeladaPatronato.Domain.Interfaces;
using PeladaPatronato.Infra.Data.EntityFrameworkCore.Contexts;
using System.Linq.Expressions;

namespace PeladaPatronato.Infra.Data.EntityFrameworkCore.Repositories
{
  public class RodadaRepository : IRodadaRepository
  {
    protected readonly PeladaPatronatoDbContext _context;
    public RodadaRepository(PeladaPatronatoDbContext context)
    {
      _context = context;
    }
    public async Task<Rodada?> ObterPorId(Guid id, params Expression<Func<Rodada, object>>[] includes)
    {
      IQueryable<Rodada> query = _context.Rodada;

      foreach (var include in includes)
      {
        query = query.Include(include);
      }

      return await query.FirstOrDefaultAsync(r => r.Id == id);

      //return await _context.Rodada.Include(r => r.Times).ThenInclude(t => t.Participantes).ThenInclude(t => t.Participante)
      //                            .Include(r => r.Partidas).ThenInclude(p => p.Eventos)
      //                            .Include(r => r.Participantes).ThenInclude(p => p.Participante)
      //    .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task CriarRodada(Rodada rodada)
    {
      await _context.Rodada.AddAsync(rodada);
    }

    public async Task Atualizar(Rodada rodada)
    {
      _context.Rodada.Update(rodada);
      //_context.SaveChanges();
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

    public async Task AdicionarTime(Guid rodadaId, RodadaTime time)
    {
      try
      {
        //var rodada = await ObterPorId(rodadaId);
        _context.Add(time);
      }
      catch (Exception)
      {

        throw;
      }
    }

    public async Task AtualizarPagamento(RodadaParticipante participante)
    {
      try
      {        
        _context.Update(participante);
      }
      catch (Exception)
      {

        throw;
      }
    }

    public async Task AdicionarPartida(Guid rodadaId, RodadaPartida partida)
    {
      try
      {
        var rodada = await ObterPorId(rodadaId);

        if (rodada == null)
          throw new Exception("Rodada não encontrada.");

        if (rodada.Status != StatusRodada.TimesDefinidos)
          throw new Exception("Times ainda não foram definidos.");

        RodadaPartida rp = new RodadaPartida(rodada.Id, partida.RodadaTimeAId, partida.RodadaTimeBId, partida.Ordem);
        rp.DefinirPosseInicial(partida.TimeComPosseInicialId.GetValueOrDefault());

        _context.Add(rp);
      }
      catch (Exception)
      {

        throw;
      }
    }

    public async Task<IEnumerable<RodadaPartida>> ListarPartidas(Guid rodadaId)
    {
      return await _context.Rodada.Include(r => r.Partidas).Where(w => w.Id == rodadaId).SelectMany(sm => sm.Partidas).ToListAsync();
    }

    public async Task<IEnumerable<RodadaTime>> ConsultarTimes(Guid id)
    {
      var times = await _context.Rodada.Include(r => r.Times)
                                       .ThenInclude(t => t.Participantes)
                                       .ThenInclude(t => t.Participante)
          .Where(r => r.Id == id).SelectMany(sm => sm.Times).ToListAsync();

      return times;
      
    }
  }
}
