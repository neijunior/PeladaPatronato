using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeladaPatronato.Domain.Entidades;

namespace PeladaPatronato.Infra.Data.EntityFrameworkCore.Configuration
{
  public class LegadoTotalEstatisticaConfiguration : IEntityTypeConfiguration<LegadoTotalEstatistica>
  {
    public void Configure(EntityTypeBuilder<LegadoTotalEstatistica> builder)
    {
      builder.ToTable("LegadoTotalEstatistica", "Legado");
      builder.HasKey(c => c.Id);
      builder.Property(c => c.Periodo).HasColumnType("varchar").IsRequired().HasMaxLength(15);
      builder.Property(c => c.TotalPartidas).HasColumnType("int").IsRequired();
      builder.Property(c => c.TotalGols).HasColumnType("int").IsRequired();
      builder.Property(c => c.TotalAssistencias).HasColumnType("int").IsRequired();

      builder.Property(p => p.MediaGols).HasColumnType("decimal(6,4)").IsRequired();
      builder.Property(p => p.MediaAssistencias).HasColumnType("decimal(6,4)").IsRequired();

      builder.HasOne(p => p.Participante)
             .WithMany() // ou .WithMany(x => x.LegadoEstatisticas) se existir a coleção na entidade Participante
             .HasForeignKey(p => p.ParticipanteId)
             .OnDelete(DeleteBehavior.Restrict);
    }
  }
}
