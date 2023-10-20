

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
        {
            public void Configure(EntityTypeBuilder<Empleado> builder)
            {
                builder.ToTable("Empleados");
    
                builder.Property(p => p.IdEmpleado)
                .HasColumnName("IdEmpleado")
                .HasColumnType("int")
                .IsRequired();

                builder.Property(p => p.Nombre)
                .HasColumnName("Nombre")
                .HasColumnType("varchar")
                .HasMaxLength(300)
                .IsRequired();

                builder.Property(p => p.FechaIngreso)
                .HasColumnName("FechaIngreso")
                .HasColumnType("datetime")
                .IsRequired();

                builder.HasOne(p => p.Cargo)
                .WithMany(p => p.Empleados)
                .HasForeignKey(p => p.IdCargoFk);

                builder.HasOne(p => p.Municipio)
                .WithMany(p => p.Empleados)
                .HasForeignKey(p => p.IdMunicipioFk);
                
            }
        }