

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class InsumoPrendaConfiguracion : IEntityTypeConfiguration<InsumoPrenda>
        {
            public void Configure(EntityTypeBuilder<InsumoPrenda> builder)
            {
        
                builder.ToTable("InsumoPrendas");
    
                builder.Property(p => p.Cantidad)
                .HasColumnName("Cantidad")
                .HasColumnType("int")
                .IsRequired();

                builder.HasOne(p => p.Insumo)
                .WithMany(p => p.InsumoPrendas)
                .HasForeignKey(p => p.IdInsumoFK);

                builder.HasOne(p => p.Prenda)
                .WithMany(p => p.InsumoPrendas)
                .HasForeignKey(p => p.IdPrendaFk);

            }
        }