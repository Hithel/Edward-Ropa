

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class OrdenConfiguration : IEntityTypeConfiguration<Orden>
        {
            public void Configure(EntityTypeBuilder<Orden> builder)
            {
                builder.ToTable("Ordenes");
    
                builder.Property(p => p.Fecha)
                .HasColumnName("Fecha")
                .HasColumnType("datetime")
                .IsRequired();

                builder.HasOne(p => p.Empleado)
                .WithMany(p => p.Ordenes)
                .HasForeignKey(p => p.IdEmpleadoFK);

                builder.HasOne(p => p.Cliente)
                .WithMany(p => p.Ordenes)
                .HasForeignKey(p => p.IdClienteFk);

                builder.HasOne(p => p.Estado)
                .WithMany(p => p.Ordenes)
                .HasForeignKey(p => p.IdEstadoFk);
            }
        }