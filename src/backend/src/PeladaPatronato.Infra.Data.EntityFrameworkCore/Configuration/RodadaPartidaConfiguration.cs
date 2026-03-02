using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeladaPatronato.Domain.Entidades;

namespace PeladaPatronato.Infra.Data.EntityFrameworkCore.Configuration
{
  public class RodadaPartidaConfiguration : IEntityTypeConfiguration<RodadaPartida>
  {
    public void Configure(EntityTypeBuilder<RodadaPartida> builder)
    {
      builder.ToTable("RodadaPartida", "PeladaPatronato");
      builder.HasKey(c => c.Id);
      builder.Property(c => c.Ordem).HasColumnType("int").IsRequired();
      builder.Property(c => c.TimeComPosseInicialId);
      builder.Property(c => c.DataHora);

      builder.HasMany(c => c.Eventos).WithOne().HasForeignKey(c => c.RodadaPartidaId).OnDelete(DeleteBehavior.Cascade);

      builder.Metadata.FindNavigation(nameof(RodadaPartida.Eventos))!.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
  }
}
