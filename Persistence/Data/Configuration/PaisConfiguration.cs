

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class PaisConfiguration : IEntityTypeConfiguration<Pais>
        {
            public void Configure(EntityTypeBuilder<Pais> builder)
            {
                builder.ToTable("Paises");

                builder.Property(p => p.Nombre)
                .HasColumnName("Nombre")
                .HasColumnType("varchar")
                .HasMaxLength(300)
                .IsRequired();
    

            }
        }