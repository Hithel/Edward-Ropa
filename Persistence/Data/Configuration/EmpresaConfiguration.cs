
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
        {
            public void Configure(EntityTypeBuilder<Empresa> builder)
            {
                builder.ToTable("Empresas");
    
                builder.Property(p => p.Nit)
                .HasColumnName("Nit")
                .HasColumnType("int")
                .IsRequired();

                builder.Property(p => p.RazonSocial)
                .HasColumnName("RazonSocial")
                .HasColumnType("varchar")
                .HasMaxLength(300)
                .IsRequired();

                builder.Property(p => p.RepresentanteLegal)
                .HasColumnName("RepresentanteLegal")
                .HasColumnType("varchar")
                .HasMaxLength(300)
                .IsRequired();

                builder.Property(p => p.FechaCreacion)
                .HasColumnName("FechaCreacion")
                .HasColumnType("datetime")
                .IsRequired();

                builder.HasOne(p => p.Municipio)
                .WithMany(p => p.Empresas)
                .HasForeignKey(p => p.IdMunicipioFk);
            }
        }