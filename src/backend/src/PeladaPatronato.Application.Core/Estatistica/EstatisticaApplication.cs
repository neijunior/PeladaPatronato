using PeladaPatronato.Application.Estatistica;
using PeladaPatronato.Application.Participante;
using PeladaPatronato.Infra.CrossCutting.Request.Estatistica;
using PeladaPatronato.Infra.CrossCutting.Response.Estatistica;
using PeladaPatronato.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeladaPatronato.Application.Core.Estatistica
{
  internal class EstatisticaApplication : IEstatisticaApplication
  {
    private readonly ILegadoEstatisticaRepository _legadoEstatisticaRepository;
    public EstatisticaApplication(ILegadoEstatisticaRepository legadoEstatisticaRepository)
    {
      _legadoEstatisticaRepository = legadoEstatisticaRepository;
    }
    public Task<IEnumerable<EstatisticaResponse>> Listar(ConsultaEstatisticaRequest paramConsulta)
    {
      throw new NotImplementedException();
    }
  }
}
