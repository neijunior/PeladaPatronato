using PeladaPatronato.Domain.Entidades;
using PeladaPatronato.Infra.CrossCutting.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeladaPatronato.Domain.Interfaces
{
  public interface IRodadaRepository : IRepositoryAggregate<Rodada>
  {
    public Task CriarRodada(Rodada rodada);
    Task<Rodada?> ObterPorId(Guid id);    
    void Atualizar(Rodada rodada);
    public Task<ICollection<Rodada>> Listar(DateTime dataInicio, DateTime? dataFim);
  }
}
