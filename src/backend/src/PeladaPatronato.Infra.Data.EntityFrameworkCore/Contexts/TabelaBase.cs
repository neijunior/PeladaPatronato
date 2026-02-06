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
        new Posicao(1, "Goleiro"),
        new Posicao(2, "Fixo"),
        new Posicao(3, "Ala"),
        new Posicao(4, "Pivo")
      );
    }

  }
}
