using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeladaPatronato.Domain.Entidades;

namespace PeladaPatronato.Infra.Data.EntityFrameworkCore.Configuration
{
  public class RodadaEventoConfiguration : IEntityTypeConfiguration<RodadaEvento>
  {
    public void Configure(EntityTypeBuilder<RodadaEvento> builder)
    {
      builder.ToTable("RodadaEvento", "PeladaPatronato");
      builder.HasKey(c => c.Id);
      builder.HasKey(x => x.Id);

      builder.Property(x => x.Tipo)
          .IsRequired();
    }
  }
}
