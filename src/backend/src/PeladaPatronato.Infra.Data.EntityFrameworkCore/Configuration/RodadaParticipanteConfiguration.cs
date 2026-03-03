using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeladaPatronato.Domain.Entidades;

namespace PeladaPatronato.Infra.Data.EntityFrameworkCore.Configuration
{
  public class RodadaParticipanteConfiguration : IEntityTypeConfiguration<RodadaParticipante>
  {
    public void Configure(EntityTypeBuilder<RodadaParticipante> builder)
    {
      builder.ToTable("RodadaParticipante", "PeladaPatronato");
      builder.HasKey(c => c.Id);
      builder.Property(x => x.Diarista).HasColumnType("bit");

      builder.HasIndex(x => new { x.RodadaId, x.ParticipanteId }).IsUnique();
    }
  }
}
