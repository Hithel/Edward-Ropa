

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class DetalleVentaConfiguration : IEntityTypeConfiguration<DetalleVenta>
        {
            public void Configure(EntityTypeBuilder<DetalleVenta> builder)
            {
                builder.ToTable("DetalleVenta");

                builder.Property(p => p.Idproducto)
                .HasColumnName("IdProducto")
                .HasColumnType("int")
                .IsRequired();
                
                builder.Property(p => p.Cantidad)
                .HasColumnName("Cantidad")
                .HasColumnType("int")
                .IsRequired();

                builder.Property(p => p.ValorUnidad)
                .HasColumnName("ValorUnidad")
                .HasColumnType("double")
                .IsRequired();

                builder.HasOne(p => p.Venta)
                .WithMany(p => p.DetalleVentas)
                .HasForeignKey(p => p.IdVentaFk);

                builder.HasOne(p => p.Talla)
                .WithMany(p => p.DetalleVentas)
                .HasForeignKey(p => p.IdTallaFk);


            }
        }