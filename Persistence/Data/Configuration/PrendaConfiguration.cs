

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class PrendaConfiguration : IEntityTypeConfiguration<Prenda>
        {
            public void Configure(EntityTypeBuilder<Prenda> builder)
            {
                builder.ToTable("Prendas");

                builder.Property(p => p.IdPrenda)
                .HasColumnName("IdPrenda")
                .HasColumnType("int")
                .IsRequired();

                builder.Property(p => p.Nombre)
                .HasColumnName("Nombre")
                .HasColumnType("varchar")
                .HasMaxLength(300)
                .IsRequired();

                builder.Property(p => p.ValorUnidadCop)
                .HasColumnName("ValorUnidadCop")
                .HasColumnType("double")
                .IsRequired();

                builder.Property(p => p.ValorUnidadUSD)
                .HasColumnName("ValorUnidadUSD")
                .HasColumnType("double")
                .IsRequired();

                builder.HasOne(p => p.Estado)
                .WithMany(p => p.Prendas)
                .HasForeignKey(p => p.IdEstadoFk);

                builder.HasOne(p => p.TipoProteccion)
                .WithMany(p => p.Prendas)
                .HasForeignKey(p => p.IdTipoProteccionFk);

                builder.HasOne(p => p.Genero)
                .WithMany(p => p.Prendas)
                .HasForeignKey(p => p.IdGeneroFk);
            }
        }