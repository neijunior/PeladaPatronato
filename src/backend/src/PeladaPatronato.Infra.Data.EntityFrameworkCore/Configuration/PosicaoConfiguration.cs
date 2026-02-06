using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeladaPatronato.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeladaPatronato.Infra.Data.EntityFrameworkCore.Configuration
{
  public class PosicaoConfiguration : IEntityTypeConfiguration<Posicao>
  {
    public void Configure(EntityTypeBuilder<Posicao> builder)
    {
      builder.ToTable("Posicao", "PeladaPatronato");
      builder.HasKey(c => c.Id);
      builder.Property(c => c.Nome).HasColumnType("varchar").IsRequired().HasMaxLength(150);      
    }
  }
}
