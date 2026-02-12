using PeladaPatronato.Infra.CrossCutting.Data;
namespace PeladaPatronato.Domain.Entidades
{
  public class Posicao 
  {
    public int Id { get; private set; }
    public string Nome { get; private set; } = string.Empty;
    public eCategoriaPosicao CategoriaPosicao { get; private set; }
    public virtual ICollection<Participante>? Participantes { get; private set; }
    public Posicao() { } 
    public Posicao(int id, string nome, eCategoriaPosicao categoriaPosicao)
    {
      Id = id;
      Nome = nome;
      CategoriaPosicao = categoriaPosicao;
    }
  }

  public enum ePosicao
  {
    Goleiro = 1,
    Fixo = 2,
    Ala = 3,
    Pivo = 4
  }

  public enum eCategoriaPosicao
  {
    Goleiro = 1,
    Linha = 2
  }
}
