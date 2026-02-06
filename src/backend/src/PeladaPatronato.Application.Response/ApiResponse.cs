namespace PeladaPatronato.Application.Response
{
  public class ApiResponse<T>
  {
    public bool Sucesso { get; private set; }
    public string? Mensagem { get; private set; }
    public T? Dados { get; private set; }
    public IEnumerable<string>? Erros { get; private set; }

    private ApiResponse() { }

    public static ApiResponse<T> Ok(T dados, string? mensagem = null)
        => new ApiResponse<T>
        {
          Sucesso = true,
          Dados = dados,
          Mensagem = mensagem
        };

    public static ApiResponse<T> Ok(string mensagem)
        => new ApiResponse<T>
        {
          Sucesso = true,
          Mensagem = mensagem
        };

    public static ApiResponse<T> Fail(string mensagem)
        => new ApiResponse<T>
        {
          Sucesso = false,
          Mensagem = mensagem
        };

    public static ApiResponse<T> Fail(IEnumerable<string> erros, string? mensagem = null)
        => new ApiResponse<T>
        {
          Sucesso = false,
          Mensagem = mensagem,
          Erros = erros
        };
  }
}
