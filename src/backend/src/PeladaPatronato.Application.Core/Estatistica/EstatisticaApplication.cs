using PeladaPatronato.Application.Estatistica;
using PeladaPatronato.Application.Participante;
using PeladaPatronato.Domain.Interfaces;
using PeladaPatronato.Infra.CrossCutting.Request.Estatistica;
using PeladaPatronato.Infra.CrossCutting.Response.Estatistica;

namespace PeladaPatronato.Application.Core.Estatistica
{
  public class EstatisticaApplication : IEstatisticaApplication
  {
    private readonly ILegadoTotalEstatisticaRepository _legadoEstatisticaRepository;
    public EstatisticaApplication(ILegadoTotalEstatisticaRepository legadoEstatisticaRepository)
    {
      _legadoEstatisticaRepository = legadoEstatisticaRepository;
    }
    public async Task<IEnumerable<EstatisticaResponse>> Listar(ConsultaEstatisticaRequest paramConsulta)
    {

      try
      {
        var lista = await _legadoEstatisticaRepository.Listar();
        return lista.Select(s => new EstatisticaResponse()
        {
          ParticipanteId = s.Participante.Id,
          Participante = s.Participante.ToResponse(),
          TotalPartidas = s.TotalPartidas,
          TotalAssistencias = s.TotalAssistencias,
          TotalGols = s.TotalGols
        }).ToList();
      }
      catch (Exception)
      {

        throw;
      }
      throw new NotImplementedException();
    }
  }
}
