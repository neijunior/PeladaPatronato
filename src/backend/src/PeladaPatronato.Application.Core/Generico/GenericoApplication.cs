using PeladaPatronato.Application.Generico;
using PeladaPatronato.Infra.CrossCutting.Response;
using PeladaPatronato.Domain.Interfaces;
using PeladaPatronato.Infra.CrossCutting.Data;
using PeladaPatronato.Domain.Entidades;
using System.Linq.Expressions;

namespace PeladaPatronato.Application.Core.Generico
{
  public class GenericoApplication : IGenericoApplication
  {
    private readonly IPosicaoRepository _posicaoRepository;
    private readonly ITimeRepository _timeRepository;
    public GenericoApplication(IPosicaoRepository posicaoRepository, ITimeRepository timeRepository)
    {
      _posicaoRepository = posicaoRepository;
      _timeRepository = timeRepository;
    }
    public async Task<IEnumerable<PosicaoResponse>> ListarPosicoes()
    {
      var lista = await _posicaoRepository.Listar(null, null);

      return lista.Select(x => new PosicaoResponse
      {
        Id = x.Id,
        Nome = x.Nome
      });
    }

    public async Task<IEnumerable<TimeResponse>> ListarTimes(bool? ativo)
    {
      Expression<Func<Domain.Entidades.Time, bool>>? filtro = null;

      if (ativo.HasValue)
        filtro = filtro.And(p => p.Ativo == ativo.HasValue);

      var lista = await _timeRepository.Listar();

      return lista.Select(x => new TimeResponse
      {
        Id = x.Id,
        Nome = x.Nome
      });
    }
  }
}
