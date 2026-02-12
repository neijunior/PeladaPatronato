using Microsoft.EntityFrameworkCore;
using PeladaPatronato.Domain.Entidades;

namespace PeladaPatronato.Infra.Data.EntityFrameworkCore.Contexts
{
  public static class TabelaBase
  {
    public static void PopularTabela(this ModelBuilder modelBuilder)
    {
      modelBuilder.PopularTabelaPosicao();
    }

    private static void PopularTabelaPosicao(this ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Posicao>().HasData(
        new Posicao(1, "Goleiro", eCategoriaPosicao.Goleiro),
        new Posicao(2, "Fixo", eCategoriaPosicao.Linha),
        new Posicao(3, "Ala", eCategoriaPosicao.Linha),
        new Posicao(4, "Pivo", eCategoriaPosicao.Linha)
      );
    }

  }
}
