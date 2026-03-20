using PeladaPatronato.Application.Rodada;
using PeladaPatronato.Domain.Entidades;
using PeladaPatronato.Domain.Interfaces;
using PeladaPatronato.Infra.CrossCutting.Data;
using PeladaPatronato.Infra.CrossCutting.Foundation;
using PeladaPatronato.Infra.CrossCutting.Request.Rodada;
using PeladaPatronato.Infra.CrossCutting.Response;
using PeladaPatronato.Infra.CrossCutting.Response.Participante;
using PeladaPatronato.Infra.CrossCutting.Response.Rodada;

namespace PeladaPatronato.Application.Core.Rodada
{
  public class RodadaApplication : IRodadaApplication
  {
    private readonly IRodadaRepository _rodadaRepository;
    private readonly ITimeRepository _timeRepository;
    private readonly IUnitOfWork _unitOfWork;
    public RodadaApplication(IRodadaRepository repository, IUnitOfWork unitOfWork, ITimeRepository timeRepository)
    {
      _rodadaRepository = repository;
      _unitOfWork = unitOfWork;
      _timeRepository = timeRepository;
    }
    public async Task<Guid> CriarRodada(CriarRodadaRequest request)
    {
      _unitOfWork.BeginTransaction();
      try
      {
        Domain.Entidades.Rodada rodada = new Domain.Entidades.Rodada(request.DataHora, request.ValorDiarista, request.Observacao, request.TempoTotal, request.TempoPorPartida);

        await _rodadaRepository.CriarRodada(rodada);
        _unitOfWork.Commit();

        return rodada.Id;
      }
      catch (Exception)
      {
        _unitOfWork.Rollback();
        throw;
      }
    }



    public async Task GerarPartidas(Guid rodadaId)
    {
      _unitOfWork.BeginTransaction();
      try
      {
        var rodada = await _rodadaRepository.ObterPorId(rodadaId)
          ?? throw new Exception("Rodada não encontrada");

        rodada.GerarPartidas();

        _rodadaRepository.Atualizar(rodada);
        _unitOfWork.Commit();
      }
      catch (Exception)
      {
        _unitOfWork.Rollback();
        throw;
      }

    }

    public async Task<PagedResponse<RodadaResponse>> Listar(ConsultarRodadaRequest request)
    {
      _unitOfWork.BeginTransaction();
      try
      {
        var rodadas = await _rodadaRepository.Listar(request.DataInicio, request.DataFim);

        int totalItens = rodadas.Count();

        var listaTratada = rodadas.Skip((request.PageNumber - 1) * request.PageSize)
          .Take(request.PageSize)
          .Select(s => new RodadaResponse
          {
            Id = s.Id,
            DataHora = s.DataHora,
            Observacao = s.Observacao,
            ValorDiarista = s.ValorDiarista,
            DescricaoStatus = s.Status.ObterDescricaoItemEnum(),
          }).ToList().OrderByDescending(o => o.DataHora).ToList();

        _unitOfWork.Commit();
        return PagedResponseExtension<RodadaResponse>.Popular(listaTratada, totalItens, request.PageNumber, request.PageSize);
      }
      catch (Exception)
      {
        _unitOfWork.Rollback();
        throw;
      }
    }

    public async Task<RodadaResponse> ObterPorId(Guid rodadaId)
    {

      try
      {
        var rodada = await _rodadaRepository.ObterPorId(rodadaId)
          ?? throw new Exception("Rodada não encontrada");

        var listaTimes = await _timeRepository.Listar();
        return new RodadaResponse
        {

          Id = rodada.Id,
          DescricaoStatus = rodada.Status.ObterDescricaoItemEnum(),
          DataHora = rodada.DataHora,
          Observacao = rodada.Observacao,
          ValorDiarista = rodada.ValorDiarista,
          participantes = rodada.Participantes.Select(p => new RodadaParticipanteResponse
          {
            Participante = p.Participante != null ? new ParticipanteResponse
            {
              Id = p.Participante.Id,
              Nome = p.Participante.Nome
            } : null,
            Diarista = p.Diarista,
            Pago = p.Pago
          }).OrderBy(o => o.Participante.Nome).ToList(),
          times = rodada.Times.Select(t => new RodadaTimeParticipanteResponse
          {
            TimeBaseId = t.TimeBaseId,
            NomeTime = listaTimes.FirstOrDefault(w => w.Id == t.TimeBaseId)?.Nome,
            Participantes = t.Participantes.Select(s => new ParticipanteResponse
            {
              Id = s.ParticipanteId,
              Nome = s.Participante.Nome,
              Ativo = s.Participante.Ativo
            }).ToList()
          }).ToList()
        };

      }
      catch (Exception)
      {

        throw;
      }
    }

    public async Task SalvarEventos(Guid rodadaId, Guid partidaId, SalvarEventosRequest request)
    {
      _unitOfWork.BeginTransaction();
      try
      {
        var rodada = await _rodadaRepository.ObterPorId(rodadaId)
          ?? throw new Exception("Rodada não encontrada");

        var eventosDominio = request.Eventos.Select(e => (partidaId, (eTipoEvento)e.TipoEvento, e.TimeId, e.ParticipanteId));

        rodada.RegistrarEventosEmLote(eventosDominio);

        _rodadaRepository.Atualizar(rodada);
        _unitOfWork.Commit();
      }
      catch (Exception)
      {
        _unitOfWork.Rollback();
        throw;
      }

    }
    public async Task AdicionarParticipante(Guid rodadaId, AdicionarParticipanteRequest request)
    {
      _unitOfWork.BeginTransaction();
      try
      {
        await _rodadaRepository.AdicionarParticipante(rodadaId, request.ParticipanteId, request.Diarista);
        await _unitOfWork.CommitAsync();
      }
      catch (Exception)
      {
        throw;

      }
    }

    public async Task CriarTimes(Guid rodadaId, CriarTimesRequest request)
    {
      _unitOfWork.BeginTransaction();
      try
      {
        var rodada = await _rodadaRepository.ObterPorId(rodadaId)
          ?? throw new Exception("Rodada não encontrada");

        var times = request.Times.Select(s => new CriarTimeInfo(s.TimeId, s.ParticipantesIds));

        foreach (var item in times)
        {
          RodadaTime time = new RodadaTime(rodadaId, item.TimeBaseId);

          foreach (var participanteId in item.ParticipantesIds)
          {
            time.AdicionarParticipante(participanteId);
          }

          await _rodadaRepository.AdicionarTime(rodadaId, time);
        }

        rodada.AtualizarStatusRodada(StatusRodada.TimesDefinidos);
        _rodadaRepository.Atualizar(rodada);

        await _unitOfWork.CommitAsync();
      }
      catch (Exception)
      {
        _unitOfWork.Rollback();
        throw;
      }
    }

    public async Task RemoverParticipante(Guid rodadaId, Guid participanteId)
    {
      _unitOfWork.BeginTransaction();
      try
      {
        await _rodadaRepository.RemoverParticipante(rodadaId, participanteId);
        await _unitOfWork.CommitAsync();
      }
      catch (Exception)
      {
        throw;

      }
    }

    public async Task AtualizarPagamento(Guid rodadaId, Guid participanteId, bool pago)
    {
      var rodada = await _rodadaRepository.ObterPorId(rodadaId);

      if (rodada == null)
        throw new Exception("Rodada não encontrada.");

      var participante = rodada.Participantes.FirstOrDefault(p => p.ParticipanteId == participanteId);

      if (participante == null)
        throw new Exception("Participante não encontrado na rodada.");

      participante.AtualizarPagamento(pago);
      await _rodadaRepository.AtualizarPagamento(participante);
    }

    public async Task CriarPartida(Guid rodadaId, CriarPartidaRequest request)
    {
      _unitOfWork.BeginTransaction();
      try
      {
        await _rodadaRepository.AdicionarPartida(rodadaId, new RodadaPartida(request.rodadaTimeAId, request.rodadaTimeBId, request.ordem, request.timeComPosseInicialId));
        await _unitOfWork.CommitAsync();
      }
      catch (Exception)
      {
        _unitOfWork.Rollback();
        throw;
      }
    }

    public async Task<IEnumerable<RodadaPartidaResponse>> ListarPartidas(Guid rodadaId)
    {
      return (await _rodadaRepository.ListarPartidas(rodadaId)).Select(s => new RodadaPartidaResponse()
      {
        Id = s.Id,
        RodadaId = s.RodadaId,
        DataHora = s.DataHora,
        Ordem = s.Ordem,
        RodadaTimeAId = s.RodadaTimeAId,
        RodadaTimeBId = s.RodadaTimeBId,
        TimeComPosseInicialId = s.TimeComPosseInicialId
      }).OrderBy(o=> o.Ordem).ToList();
    }
  }
}
