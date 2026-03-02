using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeladaPatronato.Domain.Entidades;

namespace PeladaPatronato.Infra.Data.EntityFrameworkCore.Configuration
{
  public class RodadaEventoPartidaConfiguration : IEntityTypeConfiguration<RodadaEventoPartida>
  {
    public void Configure(EntityTypeBuilder<RodadaEventoPartida> builder)
    {
      builder.ToTable("RodadaEventoPartida", "PeladaPatronato");
      builder.HasKey(c => c.Id);
      builder.Property(c => c.TipoEvento).HasColumnType("int").IsRequired();
      builder.Property(c => c.RodadaTimeId).IsRequired();
      builder.Property(c => c.RodadaPartidaParticipanteId).IsRequired();
    }
  }
}
