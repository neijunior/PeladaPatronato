using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeladaPatronato.Domain.Entidades;

namespace PeladaPatronato.Infra.Data.EntityFrameworkCore.Configuration
{
  public class RodadaTimeConfiguration : IEntityTypeConfiguration<RodadaTime>
  {
    public void Configure(EntityTypeBuilder<RodadaTime> builder)
    {
      builder.ToTable("RodadaTime", "PeladaPatronato");
      builder.HasKey(x => x.Id);

      builder.Property(x => x.Vitorias);
      builder.Property(x => x.Derrotas);
      builder.Property(x => x.Empates);
      builder.Property(x => x.GolsPro);
      builder.Property(x => x.GolsContra);

      builder.HasOne(x => x.Time).WithMany().HasForeignKey(x => x.TimeBaseId);

      builder.HasMany(x => x.Participantes).WithOne().HasForeignKey(x => x.RodadaTimeId).OnDelete(DeleteBehavior.Restrict);
      builder.Metadata.FindNavigation(nameof(RodadaTime.Participantes))!.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
  }
}
