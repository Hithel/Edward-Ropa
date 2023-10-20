

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class VentaConfiguration : IEntityTypeConfiguration<Venta>
        {
            public void Configure(EntityTypeBuilder<Venta> builder)
            {
                builder.ToTable("Ventas");
    
                builder.Property(p => p.Fecha)
                .HasColumnName("Fecha")
                .HasColumnType("datetime")
                .IsRequired();

                builder.HasOne(p => p.Empleado)
                .WithMany(p => p.Ventas)
                .HasForeignKey(p => p.IdEmpleadoFK);

                builder.HasOne(p => p.Cliente)
                .WithMany(p => p.Ventas)
                .HasForeignKey(p => p.IdClienteFK);

                builder.HasOne(p => p.FormaPago)
                .WithMany(p => p.Ventas)
                .HasForeignKey(p => p.IdFormaPagoFk);
            }
        }