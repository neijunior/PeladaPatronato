using PeladaPatronato.Application.Rodada;
using PeladaPatronato.Domain.Entidades;
using PeladaPatronato.Domain.Interfaces;
using PeladaPatronato.Infra.CrossCutting.Data;
using PeladaPatronato.Infra.CrossCutting.Request.Rodada;
using PeladaPatronato.Infra.CrossCutting.Response;
using PeladaPatronato.Infra.CrossCutting.Response.Estatistica;
using PeladaPatronato.Infra.CrossCutting.Response.Participante;
using PeladaPatronato.Infra.CrossCutting.Response.Rodada;
using PeladaPatronato.Infra.CrossCutting.Foundation;

namespace PeladaPatronato.Application.Core.Rodada
{
  public class RodadaApplication : IRodadaApplication
  {
    private readonly IRodadaRepository _rodadaRepository;
    private readonly IUnitOfWork _unitOfWork;
    public RodadaApplication(IRodadaRepository repository, IUnitOfWork unitOfWork)
    {
      _rodadaRepository = repository;
      _unitOfWork = unitOfWork;
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
            ValorDiarista = s.ValorDiarista
          }).ToList();

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
      _unitOfWork.BeginTransaction();
      try
      {
        var rodada = await _rodadaRepository.ObterPorId(rodadaId)
          ?? throw new Exception("Rodada não encontrada");

        _unitOfWork.Commit();
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
            Participantes = t.Participantes.Select(s => new ParticipanteResponse
            {
              Id = s.ParticipanteId,
              Nome = s.Participante.Nome
            }).ToList()
          }).ToList()
        };

      }
      catch (Exception)
      {
        _unitOfWork.Rollback();
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

  }
}
