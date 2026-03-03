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
      builder.Property(x => x.Observacao).HasColumnType("varchar").HasMaxLength(500);
      builder.Property(x => x.TempoTotal).IsRequired();
      builder.Property(x => x.TempoPorPartida).IsRequired();
      builder.Property(x => x.Status).HasColumnType("int").IsRequired();

      builder.HasMany(x => x.Times).WithOne().HasForeignKey(x => x.RodadaId).OnDelete(DeleteBehavior.Restrict);
      builder.Metadata.FindNavigation(nameof(Rodada.Times))!.SetPropertyAccessMode(PropertyAccessMode.Field);

      builder.HasMany(x => x.Partidas).WithOne().HasForeignKey(x => x.RodadaId).OnDelete(DeleteBehavior.Restrict);
      builder.Metadata.FindNavigation(nameof(Rodada.Partidas))!.SetPropertyAccessMode(PropertyAccessMode.Field);

      builder.Metadata.FindNavigation(nameof(Rodada.Participantes))!.SetField("_participantes");

      builder.HasMany(x => x.Participantes).WithOne().HasForeignKey(x => x.RodadaId).OnDelete(DeleteBehavior.Restrict);
      builder.Metadata.FindNavigation(nameof(Rodada.Participantes))!.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
  }
}
