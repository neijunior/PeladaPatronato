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

    public async Task CriarTimes(Guid rodadaId, CriarTimesRequest request)
    {
      _unitOfWork.BeginTransaction();
      try
      {
        var rodada = await _rodadaRepository.ObterPorId(rodadaId)
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
          DataHora = rodada.DataHora,
          Observacao = rodada.Observacao,
          ValorDiarista = rodada.ValorDiarista,
          //TempoTotal = rodada.TempoTotal,
          //TempoPorPartida = rodada.TempoPorPartida,
          //Partidas = rodada.Partidas.Select(p => new PartidaResponse
          //{
          //  Id = p.Id,
          //  TimeA = new TimeResponse
          //  {
          //    Id = p.TimeA.Id,
          //    Participantes = p.TimeA.Participantes.Select(pa => new ParticipanteResponse
          //    {
          //      Id = pa.Id,
          //      Nome = pa.Nome
          //    }).ToList()
          //  },
          //  TimeB = new TimeResponse
          //  {
          //    Id = p.TimeB.Id,
          //    Participantes = p.TimeB.Participantes.Select(pb => new ParticipanteResponse
          //    {
          //      Id = pb.Id,
          //      Nome = pb.Nome
          //    }).ToList()
          //  },
          //  Eventos = p.Eventos.Select(e => new EventoResponse
          //  {
          //    Id = e.Id,
          //    TipoEvento = (int)e.TipoEvento,
          //    TimeId = e.TimeId,
          //    ParticipanteId = e.ParticipanteId
          //  }).ToList()
          //}).ToList()
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
  }
}
