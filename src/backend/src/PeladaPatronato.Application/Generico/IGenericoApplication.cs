using PeladaPatronato.Application.Request.Participante;
using PeladaPatronato.Application.Response;
using PeladaPatronato.Application.Response.Participante;
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
  }
}
