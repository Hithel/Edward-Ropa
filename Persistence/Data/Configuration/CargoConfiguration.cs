

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class CargoConfiguration : IEntityTypeConfiguration<Cargo>
        {
            public void Configure(EntityTypeBuilder<Cargo> builder)
            {
                builder.ToTable("Cargos");
    
                builder.Property(p => p.Descripcion)
                .HasColumnName("Descripcion")
                .HasColumnType("varchar")
                .HasMaxLength(300)
                .IsRequired();

                builder.Property(p => p.SueldoBase)
                .HasColumnName("SueldoBase")
                .HasColumnType("double")
                .IsRequired();


            }
        }