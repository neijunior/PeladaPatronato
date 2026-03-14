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
      builder.Property(x => x.RodadaParticipanteId).IsRequired();
    }
  }
}
