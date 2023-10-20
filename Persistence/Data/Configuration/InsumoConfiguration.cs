

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class InsumoConfiguration : IEntityTypeConfiguration<Insumo>
        {
            public void Configure(EntityTypeBuilder<Insumo> builder)
            {
                builder.ToTable("Insumos");
    
                builder.Property(p => p.Nombre)
                .HasColumnName("Nombre")
                .HasColumnType("varchar")
                .HasMaxLength(300)
                .IsRequired();

                builder.Property(p => p.ValorUnidad)
                .HasColumnName("ValorUnidad")
                .HasColumnType("double")
                .IsRequired();

                builder.Property(p => p.StockMin)
                .HasColumnName("StockMin")
                .HasColumnType("int")
                .IsRequired();

                builder.Property(p => p.Stockmax)
                .HasColumnName("Stockmax")
                .HasColumnType("int")
                .IsRequired();

                builder
                .HasMany(p => p.Proveedores)
                .WithMany(r => r.Insumos)
                .UsingEntity<InsumoProveedor>(

                    j => j
                    .HasOne(pt => pt.Proveedor)
                    .WithMany(t => t.InsumoProveedores)
                    .HasForeignKey(ut => ut.IdProveedorFk),


                    j => j
                    .HasOne(et => et.Insumo)
                    .WithMany(et => et.InsumoProveedores)
                    .HasForeignKey(el => el.IdInsumoFk),

                    j =>
                    {
                        j.ToTable("InsumoProveedor");
                        j.HasKey(t => new { t.IdInsumoFk, t.IdProveedorFk });

                    });



            }
        }