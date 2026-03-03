using PeladaPatronato.Infra.CrossCutting.Response;

namespace PeladaPatronato.Application.Core
{
  public static class PagedResponseExtension<T> where T : class
  {
    public static PagedResponse<T> Popular(ICollection<T> listaTratada, int totalItens, int pageNumber, int pageSize)
    {
      return new PagedResponse<T>
      {
        Items = listaTratada,
        TotalCount = totalItens,
        PageNumber = pageNumber,
        PageSize = pageSize
      };
    }
  }
}
