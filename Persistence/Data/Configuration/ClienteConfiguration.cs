

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
        {
            public void Configure(EntityTypeBuilder<Cliente> builder)
            {
                builder.ToTable("Clientes");

                builder.Property(p => p.IdCliente)
                .HasColumnName("IdCLiente")
                .HasColumnType("int")
                .IsRequired();
                
                builder.Property(p => p.Nombre)
                .HasColumnName("Nombre")
                .HasColumnType("varchar")
                .HasMaxLength(300)
                .IsRequired();

                builder.Property(p => p.FechaRegistro)
                .HasColumnName("FechaRegistro")
                .HasColumnType("datetime")
                .IsRequired();

                builder.HasOne(p => p.TipoPersona)
                .WithMany(p => p.Clientes)
                .HasForeignKey(p => p.IdTipoPersonaFK);

                builder.HasOne(p => p.Municipio)
                .WithMany(p => p.Clientes)
                .HasForeignKey(p => p.IdMunicipioFk);
            }
        }