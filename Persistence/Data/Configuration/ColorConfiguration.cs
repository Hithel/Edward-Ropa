
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
        {
            public void Configure(EntityTypeBuilder<Color> builder)
            {
                builder.ToTable("Colores");
    
                builder.Property(p => p.Descripcion)
                .HasColumnName("Descripcion")
                .HasColumnType("varchar")
                .HasMaxLength(300)
                .IsRequired();

                
            }
        }