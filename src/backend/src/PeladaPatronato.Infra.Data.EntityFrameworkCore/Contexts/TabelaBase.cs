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
        new Posicao(1, "Goleiro", Domain.Enums.eCategoriaPosicao.Goleiro),
        new Posicao(2, "Fixo", Domain.Enums.eCategoriaPosicao.Linha),
        new Posicao(3, "Ala", Domain.Enums.eCategoriaPosicao.Linha),
        new Posicao(4, "Pivo", Domain.Enums.eCategoriaPosicao.Linha)
      );
    }

  }
}
