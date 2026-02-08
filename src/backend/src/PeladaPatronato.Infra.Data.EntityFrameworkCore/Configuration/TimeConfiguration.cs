using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeladaPatronato.Domain.Entidades;

namespace PeladaPatronato.Infra.Data.EntityFrameworkCore.Configuration
{
  public class TimeConfiguration : IEntityTypeConfiguration<Time>
  {
    public void Configure(EntityTypeBuilder<Time> builder)
    {
      builder.ToTable("Time", "PeladaPatronato");
      builder.HasKey(c => c.Id);
      builder.Property(c => c.Nome).HasColumnType("varchar").IsRequired().HasMaxLength(100);      
    }
  }
}
