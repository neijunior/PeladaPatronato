using PeladaPatronato.Domain.Entidades;

namespace PeladaPatronato.Domain.Interfaces
{
  public interface IParticipanteRepository : IRepository<Participante>
  {
    Task<Participante> Consultar(Guid Id);
    Task<Participante> Salvar(Participante participante);
    Task<IEnumerable<Participante>> Listar();
    Task<Participante> Inativar();
  }
}
