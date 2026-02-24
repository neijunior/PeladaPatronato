
using PeladaPatronato.Domain.Entidades;
using PeladaPatronato.Infra.CrossCutting.Data;

namespace PeladaPatronato.Domain.Interfaces
{
  public interface IParticipanteRepository : IRepository<Participante>
  {
    Task<Participante?> ObterPorNomeUsuario(string nomeUsuario);
    
  }
}
