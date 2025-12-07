using PeladaPatronato.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeladaPatronato.Domain.Interfaces
{
  public interface IParticipanteRepository : IRepository<Participante>
  {
    Task<Participante> Consultar(Guid Id);
    Task<Participante> Salvar();
    Task<IEnumerable<Participante>> Listar();
    Task<Participante> Inativar();
  }
}
