using PeladaPatronato.Application.Response.Participante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeladaPatronato.Application.Participante
{
  public interface IParticipanteApplication
  {
    Task<ParticipanteResponse> Consultar(Guid Id);
    Task<ParticipanteResponse> Salvar();
    Task<IEnumerable<ParticipanteResponse>> Listar();
    Task<ParticipanteResponse> Inativar();
  }
}
