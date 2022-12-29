using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ModelMaps
{
	public class PrestamoDetalleMap : IEntityTypeConfiguration<PrestamoDetalle>
    {
        public void Configure(EntityTypeBuilder<PrestamoDetalle> builder)
        {
            builder.ToTable("prestamos_detalles");
            builder.HasKey(t => new { t.IdPrestamo, t.IdLibro });
            builder.Property(t => t.IdPrestamo).HasColumnName("id_prestamo");
            builder.Property(t => t.IdLibro).HasColumnName("id_libro");
            builder.Property(t => t.Devuelto).HasColumnName("devuelto");
            builder.Property(t => t.Mora).HasColumnName("mora");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");

            builder.HasOne(t => t.Libro).WithMany(t => t.PrestamoDetalles).HasForeignKey(t => t.IdLibro);
        }
    }
}

