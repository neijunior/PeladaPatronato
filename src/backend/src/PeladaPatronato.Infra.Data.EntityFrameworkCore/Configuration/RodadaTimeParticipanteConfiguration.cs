using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeladaPatronato.Domain.Entidades;

namespace PeladaPatronato.Infra.Data.EntityFrameworkCore.Configuration
{
  public class RodadaTimeParticipanteConfiguration : IEntityTypeConfiguration<RodadaTimeParticipante>
  {
    public void Configure(EntityTypeBuilder<RodadaTimeParticipante> builder)
    {
      builder.ToTable("RodadaTimeParticipante", "PeladaPatronato");
      builder.HasKey(x => x.Id);

      builder.Property(x => x.RodadaTimeId).IsRequired();

      builder.Property(x => x.ParticipanteId).IsRequired();

      builder.HasOne(x => x.RodadaTime).WithMany(x => x.Participantes).HasForeignKey(x => x.RodadaTimeId);

      builder.HasOne(x => x.Participante).WithMany().HasForeignKey(x => x.ParticipanteId);
    }
  }
}
