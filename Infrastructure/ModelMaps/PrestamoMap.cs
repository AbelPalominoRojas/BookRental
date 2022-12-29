using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ModelMaps
{
	public class PrestamoMap : IEntityTypeConfiguration<Prestamo>
    {
        public void Configure(EntityTypeBuilder<Prestamo> builder)
        {
            builder.ToTable("prestamos");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id");
            builder.Property(t => t.FechaPrestamo).HasColumnName("fecha_prestamo");
            builder.Property(t => t.FechaDevolucion).HasColumnName("fecha_devolucion");
            builder.Property(t => t.EstadoPrestamo).HasColumnName("estado_prestamo");
            builder.Property(t => t.IdSolicitante).HasColumnName("id_solicitante");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");

            builder.HasOne(t => t.Solicitante).WithMany(t => t.Prestamos).HasForeignKey(t => t.IdSolicitante);
        }
    }
}

