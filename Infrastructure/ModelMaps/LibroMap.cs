using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ModelMaps
{
    public class LibroMap : IEntityTypeConfiguration<Libro>
    {
        public void Configure(EntityTypeBuilder<Libro> builder)
        {
            builder.ToTable("libros");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id");
            builder.Property(t => t.Isbn).HasColumnName("isbn");
            builder.Property(t => t.Titulo).HasColumnName("titulo");
            builder.Property(t => t.Autores).HasColumnName("autores");
            builder.Property(t => t.Edicion).HasColumnName("edicion");
            builder.Property(t => t.Anio).HasColumnName("anio");
            builder.Property(t => t.IdEditorial).HasColumnName("id_editorial");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}

