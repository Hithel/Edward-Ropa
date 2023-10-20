

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class EstadoConfiguration : IEntityTypeConfiguration<Estado>
        {
            public void Configure(EntityTypeBuilder<Estado> builder)
            {
                builder.ToTable("Estados");
    
                builder.Property(p => p.Descripcion)
                .HasColumnName("Descripcion")
                .HasColumnType("varchar")
                .HasMaxLength(300)
                .IsRequired();

                builder.HasOne(p => p.TipoEstado)
                .WithMany(p => p.Estados)
                .HasForeignKey(p => p.IdTipoEstadoFk);
            }
        }