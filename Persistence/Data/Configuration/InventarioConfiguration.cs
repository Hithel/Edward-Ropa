

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class InventarioConfiguration : IEntityTypeConfiguration<Inventario>
        {
            public void Configure(EntityTypeBuilder<Inventario> builder)
            {
                builder.ToTable("Inventario");
    
                builder.Property(p => p.CodInv)
                .HasColumnName("IdEmpleado")
                .HasColumnType("int")
                .IsRequired();

                builder.Property(p => p.ValorVtaCop)
                .HasColumnName("ValorVtaCop")
                .HasColumnType("double")
                .IsRequired();

                builder.Property(p => p.ValorVtaUsd)
                .HasColumnName("ValorVtaUsd")
                .HasColumnType("Double")
                .IsRequired();

                builder.HasOne(p => p.Prenda)
                .WithMany(p => p.Inventarios)
                .HasForeignKey(p => p.IdPrendaFk);

                
            }
        }