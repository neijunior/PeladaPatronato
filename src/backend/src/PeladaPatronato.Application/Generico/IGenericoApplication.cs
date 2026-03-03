using PeladaPatronato.Infra.CrossCutting.Request.Participante;
using PeladaPatronato.Infra.CrossCutting.Response;
using PeladaPatronato.Infra.CrossCutting.Response.Participante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeladaPatronato.Application.Generico
{
  public interface IGenericoApplication
  {
    Task<IEnumerable<PosicaoResponse>> ListarPosicoes();
    Task<IEnumerable<TimeResponse>> ListarTimes(bool? ativo);
  }
}
