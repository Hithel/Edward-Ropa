

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class InventarioTallaConfiguracion : IEntityTypeConfiguration<InventatioTalla>
        {
            public void Configure(EntityTypeBuilder<InventatioTalla> builder)
            {
                builder.ToTable("InventarioTalla");
    
                builder.Property(p => p.Cantidad)
                .HasColumnName("Cantidad")
                .HasColumnType("int")
                .IsRequired();

                builder.HasOne(p => p.Inventario)
                .WithMany(p => p.InventatioTallas)
                .HasForeignKey(p => p.IdInventarioFk);

                builder.HasOne(p => p.Talla)
                .WithMany(p => p.InventatioTallas)
                .HasForeignKey(p => p.IdTallaFK);


            }
        }