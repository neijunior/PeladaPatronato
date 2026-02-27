using PeladaPatronato.Application.Estatistica;
using PeladaPatronato.Application.Participante;
using PeladaPatronato.Domain.Entidades;
using PeladaPatronato.Domain.Interfaces;
using PeladaPatronato.Infra.CrossCutting.Request.Estatistica;
using PeladaPatronato.Infra.CrossCutting.Response;
using PeladaPatronato.Infra.CrossCutting.Response.Estatistica;
using PeladaPatronato.Infra.CrossCutting.Response.Participante;

namespace PeladaPatronato.Application.Core.Estatistica
{
  public class EstatisticaApplication : IEstatisticaApplication
  {
    private readonly ILegadoTotalEstatisticaRepository _legadoEstatisticaRepository;
    public EstatisticaApplication(ILegadoTotalEstatisticaRepository legadoEstatisticaRepository)
    {
      _legadoEstatisticaRepository = legadoEstatisticaRepository;
    }
    public async Task<PagedResponse<EstatisticaResponse>> Listar(ConsultaEstatisticaRequest paramConsulta)
    {

      try
      { 
        var lista = await _legadoEstatisticaRepository.Listar(paramConsulta);

        var totalCount = lista.Count();

        var listaTratada = lista.Select(s => new EstatisticaResponse()
        {
          ParticipanteId = s.Participante.Id,
          Participante = s.Participante.ToResponse(),
          Periodo = s.Periodo,
          TotalPartidas = s.TotalPartidas,
          TotalAssistencias = s.TotalAssistencias,
          TotalGols = s.TotalGols
        }).ToList();

        return new PagedResponse<EstatisticaResponse>
        {
          Items = listaTratada,
          TotalCount = totalCount,
          PageNumber = paramConsulta.PageNumber,
          PageSize = paramConsulta.PageSize
        };
      }
      catch (Exception)
      {

        throw;
      }
      throw new NotImplementedException();
    }
  }
}
