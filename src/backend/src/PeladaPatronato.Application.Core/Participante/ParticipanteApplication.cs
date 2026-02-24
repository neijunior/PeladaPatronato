using Microsoft.EntityFrameworkCore;
using PeladaPatronato.Application.Participante;
using PeladaPatronato.Infra.CrossCutting.Request.Participante;
using PeladaPatronato.Infra.CrossCutting.Response.Participante;
using PeladaPatronato.Domain.Entidades;
using PeladaPatronato.Domain.Interfaces;
using PeladaPatronato.Infra.CrossCutting.Foundation;
using System.Linq.Expressions;
using System.Diagnostics.CodeAnalysis;

namespace PeladaPatronato.Application.Core.Participante
{
  public class ParticipanteApplication : IParticipanteApplication
  {
    private readonly IParticipanteRepository _participanteRepository;
    public ParticipanteApplication(IParticipanteRepository participanteRepository)
    {
      _participanteRepository = participanteRepository;
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

    public async Task<IEnumerable<ParticipanteResponse>> Listar(ConsultaParticipanteRequest paramConsulta)
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

      return participantes.Select(p => p.ToResponse());
    }

    public async Task<ParticipanteResponse> Salvar(ParticipanteRequest request)
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
      }
      
      return participante.ToResponse();
    }
  }
}
