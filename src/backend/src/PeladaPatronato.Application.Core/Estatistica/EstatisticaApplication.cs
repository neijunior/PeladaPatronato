using Microsoft.EntityFrameworkCore;
using PeladaPatronato.Application.Estatistica;
using PeladaPatronato.Application.Participante;
using PeladaPatronato.Domain.Entidades;
using PeladaPatronato.Domain.Interfaces;
using PeladaPatronato.Infra.CrossCutting.Request.Estatistica;
using PeladaPatronato.Infra.CrossCutting.Response;
using PeladaPatronato.Infra.CrossCutting.Response.Estatistica;
using PeladaPatronato.Infra.CrossCutting.Response.Participante;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PeladaPatronato.Application.Core.Estatistica
{
  public class EstatisticaApplication : IEstatisticaApplication
  {
    private readonly ILegadoTotalEstatisticaRepository _legadoEstatisticaRepository;
    public EstatisticaApplication(ILegadoTotalEstatisticaRepository legadoEstatisticaRepository)
    {
      _legadoEstatisticaRepository = legadoEstatisticaRepository;
    }

    private async Task<IEnumerable<LegadoTotalEstatistica>> ListarLegadoTotalEstatistica(ConsultaEstatisticaRequest paramConsulta)
    {
      Expression<Func<Domain.Entidades.LegadoTotalEstatistica, bool>>? filtro = null;
      Func<IQueryable<Domain.Entidades.LegadoTotalEstatistica>, IQueryable<Domain.Entidades.LegadoTotalEstatistica>>? include = null;

      include = q => q.Include(p => p.Participante.Posicao);      

      if (!string.IsNullOrEmpty(paramConsulta.NomeParticipante))
      {
        filtro = filtro.And(p => p.Participante.Nome.Contains(paramConsulta.NomeParticipante));
      }

      if (paramConsulta.IdPosicao.HasValue)
      {
        filtro = filtro.And(p => p.Participante.IdPosicaoPreferida == paramConsulta.IdPosicao.Value);
      }

      if (!string.IsNullOrEmpty(paramConsulta.Periodo))
      {
        filtro = filtro.And(p => p.Periodo == paramConsulta.Periodo);
      }

      //public DateTime? DataInicio { get; set; }
      //public DateTime? DataFim { get; set; }

      var lista = await _legadoEstatisticaRepository.Listar(filtro, include);

      return lista;
    }

    public async Task<PagedResponse<EstatisticaResponse>> Listar(ConsultaEstatisticaRequest paramConsulta)
    {

      

      try
      { 
        var lista = await ListarLegadoTotalEstatistica(paramConsulta);

        var totalCount = lista.Count();

        if (paramConsulta.ordenacoes != null && paramConsulta.ordenacoes.Any())
        {
          // Cria a string de ordenação dinâmica
          var ordenacaoString = string.Join(", ",
              paramConsulta.ordenacoes.Select(o =>
              {
                var dir = o.Direcao?.ToLower() == "desc" ? "descending" : "ascending";
                return $"{o.Campo} {dir}";
              })
          );

          // Aplica a ordenação
          lista = lista.AsQueryable().OrderBy(ordenacaoString).ToList();
        }

        var listaTratada = lista.Skip((paramConsulta.PageNumber - 1) * paramConsulta.PageSize)
          .Take(paramConsulta.PageSize)
          .Select(s => new EstatisticaResponse()
        {
          ParticipanteId = s.Participante.Id,
          Participante = s.Participante.ToResponse(),
          Periodo = s.Periodo,
          TotalPartidas = s.TotalPartidas,
          TotalAssistencias = s.TotalAssistencias,
          TotalGols = s.TotalGols
        }).ToList();

        return PagedResponseExtension<EstatisticaResponse>.Popular(listaTratada, totalCount, paramConsulta.PageNumber, paramConsulta.PageSize);        
      }
      catch (Exception)
      {
        throw;
      }
    }
  }
}
