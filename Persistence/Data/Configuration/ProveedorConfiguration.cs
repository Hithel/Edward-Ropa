

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
        {
            public void Configure(EntityTypeBuilder<Proveedor> builder)
            {
                builder.ToTable("Proveedor");
    
                builder.Property(p => p.NitProveedor)
                .HasColumnName("NitProveedor")
                .HasColumnType("int")
                .IsRequired();

                builder.Property(p => p.Nombre)
                .HasColumnName("Nombre")
                .HasColumnType("varchar")
                .HasMaxLength(300)
                .IsRequired();

                builder.HasOne(p => p.TipoPersona)
                .WithMany(p => p.Proveedores)
                .HasForeignKey(p => p.IdTipoPersonaFK);

                builder.HasOne(p => p.Municipio)
                .WithMany(p => p.Proveedores)
                .HasForeignKey(p => p.IdMunicipioFk);
            }
        }