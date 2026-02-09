using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeladaPatronato.Domain.Entidades;

namespace PeladaPatronato.Infra.Data.EntityFrameworkCore.Configuration
{
  public class RodadaConfiguration : IEntityTypeConfiguration<Rodada>
  {
    public void Configure(EntityTypeBuilder<Rodada> builder)
    {
      builder.ToTable("Rodada", "PeladaPatronato");
      builder.HasKey(x => x.Id);
      builder.Property(x => x.DataHora).IsRequired();
      builder.Property(x => x.ValorDiarista).HasPrecision(10, 2);
      builder.Property(c => c.Observacao).HasColumnType("varchar").HasMaxLength(500);
      builder.HasMany(x => x.Times).WithOne().HasForeignKey(x => x.RodadaId).OnDelete(DeleteBehavior.Cascade);
    }
  }
}
