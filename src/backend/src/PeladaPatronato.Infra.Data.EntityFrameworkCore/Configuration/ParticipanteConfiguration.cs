using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeladaPatronato.Domain.Entidades;

namespace PeladaPatronato.Infra.Data.EntityFrameworkCore.Configuration
{
  public class ParticipanteConfiguration : IEntityTypeConfiguration<Participante>
  {
    public void Configure(EntityTypeBuilder<Participante> builder)
    {
      builder.ToTable("Participante", "PeladaPatronato");
      builder.HasKey(c => c.Id);
      builder.Property(c => c.Nome).HasColumnType("varchar").IsRequired().HasMaxLength(150);
      builder.Property(c => c.Apelido).HasColumnType("varchar").HasMaxLength(50);
      builder.Property(c => c.Telefone).HasColumnType("varchar").HasMaxLength(11);
      builder.Property(c => c.Ativo).IsRequired().HasDefaultValue(true);
      builder.Property(c => c.DataCadastro).HasColumnType("datetime").IsRequired();

    }
  }
}
