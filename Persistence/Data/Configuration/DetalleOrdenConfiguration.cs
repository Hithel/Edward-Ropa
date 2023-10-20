

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class DetalleOrdenConfiguration : IEntityTypeConfiguration<DetalleOrden>
        {
            public void Configure(EntityTypeBuilder<DetalleOrden> builder)
            {
                builder.ToTable("DetalleOrden");
    
                builder.Property(p => p.CantidadProducir)
                .HasColumnName("CantidadProducir")
                .HasColumnType("int")
                .IsRequired();

                builder.Property(p => p.CantidadProducidad)
                .HasColumnName("CantidadProducidad")
                .HasColumnType("int")
                .IsRequired();

                builder.HasOne(p => p.Orden)
                .WithMany(p => p.DetalleOrdenes)
                .HasForeignKey(p => p.IdOrdenFK);

                builder.HasOne(p => p.Prenda)
                .WithMany(p => p.DetalleOrdenes)
                .HasForeignKey(p => p.IdPrendaFk);

                builder.HasOne(p => p.Estado)
                .WithMany(p => p.DetalleOrdenes)
                .HasForeignKey(p => p.IdEstadoFk);
            }
        }