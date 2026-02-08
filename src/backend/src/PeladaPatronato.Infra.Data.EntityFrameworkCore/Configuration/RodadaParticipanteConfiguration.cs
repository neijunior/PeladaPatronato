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
      builder.HasKey(x => x.Id);

      builder.HasMany(x => x.Eventos)
          .WithOne()
          .HasForeignKey(x => x.RodadaParticipanteId)
          .OnDelete(DeleteBehavior.Cascade);

      // Mesmo jogador pode jogar na mesma rodada
      // DESDE QUE seja em times diferentes
      builder.HasIndex(x => new { x.RodadaTimeId, x.ParticipanteId })
          .IsUnique();
    }
  }
}
