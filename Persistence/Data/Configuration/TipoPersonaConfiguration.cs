

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class TipoPersonaConfiguration : IEntityTypeConfiguration<TipoPersona>
        {
            public void Configure(EntityTypeBuilder<TipoPersona> builder)
            {
                builder.ToTable("TipoPersona");
    
                builder.Property(p => p.Nombre)
                .HasColumnName("Nombre")
                .HasColumnType("varchar")
                .HasMaxLength(300)
                .IsRequired();
            }
        }