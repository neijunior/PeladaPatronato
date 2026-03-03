using PeladaPatronato.Application.Rodada;
using PeladaPatronato.Domain.Entidades;
using PeladaPatronato.Domain.Interfaces;
using PeladaPatronato.Infra.CrossCutting.Data;
using PeladaPatronato.Infra.CrossCutting.Request.Rodada;
using PeladaPatronato.Infra.CrossCutting.Response;
using PeladaPatronato.Infra.CrossCutting.Response.Estatistica;
using PeladaPatronato.Infra.CrossCutting.Response.Rodada;

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

    public async Task CriarTimes(CriarTimesRequest request)
    {
      _unitOfWork.BeginTransaction();
      try
      {
        var rodada = await _rodadaRepository.ObterPorId(request.rodadaId)
          ?? throw new Exception("Rodada não encontrada");

        var times = request.Times.Select(s => new CriarTimeInfo(s.TimeId, s.ParticipantesIds));

        rodada.DefinirTimes(times);

        _rodadaRepository.Atualizar(rodada);
        _unitOfWork.Commit();
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

        return PagedResponseExtension<RodadaResponse>.Popular(listaTratada, totalItens, request.PageNumber, request.PageSize);
      }
      catch (Exception)
      {
        _unitOfWork.Rollback();
        throw;
      }
    }

    public async Task SalvarEventos(SalvarEventosRequest request)
    {
      _unitOfWork.BeginTransaction();
      try
      {
        var rodada = await _rodadaRepository.ObterPorId(request.rodadaId)
          ?? throw new Exception("Rodada não encontrada");

        var eventosDominio = request.Eventos.Select(e => (e.PartidaId, (eTipoEvento)e.TipoEvento, e.TimeId, e.ParticipanteId));

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
  }
}
