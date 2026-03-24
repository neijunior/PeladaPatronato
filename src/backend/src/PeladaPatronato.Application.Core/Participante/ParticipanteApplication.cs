using Microsoft.EntityFrameworkCore;
using PeladaPatronato.Application.Participante;
using PeladaPatronato.Domain.Entidades;
using PeladaPatronato.Domain.Interfaces;
using PeladaPatronato.Infra.CrossCutting.Data;
using PeladaPatronato.Infra.CrossCutting.Foundation;
using PeladaPatronato.Infra.CrossCutting.Request.Participante;
using PeladaPatronato.Infra.CrossCutting.Response;
using PeladaPatronato.Infra.CrossCutting.Response.Participante;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PeladaPatronato.Application.Core.Participante
{
  public class ParticipanteApplication : IParticipanteApplication
  {
    private readonly IParticipanteRepository _participanteRepository;
    private readonly IUnitOfWork _unitOfWork;
    public ParticipanteApplication(IParticipanteRepository participanteRepository, IUnitOfWork unitOfWork)
    {
      _participanteRepository = participanteRepository;
      _unitOfWork = unitOfWork;
    }
    public async Task<ParticipanteResponse?> Consultar(Guid Id)
    {
      var participante = await _participanteRepository.ObterPorId(Id);
      return participante.ToResponse();
    }

    public async Task<ParticipanteResponse> Inativar(Guid Id)
    {
      var participante = await _participanteRepository.ObterPorId(Id);

      if (participante is null)
        throw new Exception("Participante não encontrado");

      participante.Inativar();

      await _participanteRepository.Atualizar(participante);

      return participante.ToResponse();
    }

    public async Task<PagedResponse<ParticipanteResponse>> Listar(ConsultaParticipanteRequest paramConsulta)
    {
      Expression<Func<Domain.Entidades.Participante, bool>>? filtro = null;
      Func<IQueryable<Domain.Entidades.Participante>, IQueryable<Domain.Entidades.Participante>>? include = null;

      if (paramConsulta.ExibePosicao.HasValue && paramConsulta.ExibePosicao.Value)
      {
        include = q => q.Include(p => p.Posicao);
      }

      if (paramConsulta.Ativo.HasValue)
      {
        filtro = filtro.And(p => p.Ativo == paramConsulta.Ativo.Value);
      }

      if (paramConsulta.Id.HasValue)
      {
        filtro = filtro.And(p => p.Id == paramConsulta.Id.Value);
      }

      if (!string.IsNullOrWhiteSpace(paramConsulta.Nome))
      {
        filtro = filtro.And(p => p.Nome.Contains(paramConsulta.Nome) || p.Apelido!.Contains(paramConsulta.Nome));
      }

      if (paramConsulta.IdPosicao > 0)
      {
        filtro = filtro.And(p => p.IdPosicaoPreferida == (int)paramConsulta.IdPosicao);
      }

      var participantes = await _participanteRepository.Listar(filtro, include);



      var totalCount = participantes.Count();

      var items = participantes.OrderBy(o => o.Nome)
          .Skip((paramConsulta.PageNumber - 1) * paramConsulta.PageSize)
          .Take(paramConsulta.PageSize)
          .ToList();

      //return participantes.Select(p => p.ToResponse());

      return new PagedResponse<ParticipanteResponse>
      {
        Items = items.Select(p => p.ToResponse()),
        TotalCount = totalCount,
        PageNumber = paramConsulta.PageNumber,
        PageSize = paramConsulta.PageSize
      };
    }

    public async Task<ParticipanteResponse> Salvar(ParticipanteRequest request)
    {
      _unitOfWork.BeginTransaction();
      try
      {
        Domain.Entidades.Participante participante;
        if (request.Id == Guid.Empty)
        {
          participante = request.ToEntity();
          await _participanteRepository.Adicionar(participante);
        }
        else
        {
          participante = await _participanteRepository.ObterPorId(request.Id);
          if (participante is null)
            throw new Exception("Participante não encontrado");
          participante.Atualizar(request.Nome, request.Apelido, request.Telefone, (request.PosicaoPreferida.HasValue ? (Domain.Entidades.ePosicao)request.PosicaoPreferida.Value : null), request.Ativo, request.Email);
          await _participanteRepository.Atualizar(participante);

          //_unitOfWork.await _context.SaveChangesAsync();
          await _unitOfWork.CommitAsync();
        }

        return participante.ToResponse();
      }
      catch (Exception)
      {

        throw;
      }
    }
  }
}
