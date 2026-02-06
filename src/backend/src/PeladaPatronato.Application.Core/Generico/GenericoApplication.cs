using PeladaPatronato.Application.Generico;
using PeladaPatronato.Application.Response;
using PeladaPatronato.Domain.Interfaces;

namespace PeladaPatronato.Application.Core.Generico
{
  public class GenericoApplication : IGenericoApplication
  {
    private readonly IPosicaoRepository _posicaoRepository;
    public GenericoApplication(IPosicaoRepository posicaoRepository)
    {
      _posicaoRepository = posicaoRepository;
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
  }
}
