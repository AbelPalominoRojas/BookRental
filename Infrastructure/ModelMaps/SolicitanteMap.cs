using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ModelMaps
{
    public class SolicitanteMap : IEntityTypeConfiguration<Solicitante>
    {
        public void Configure(EntityTypeBuilder<Solicitante> builder)
        {
            builder.ToTable("solicitantes");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id");
            builder.Property(t => t.NombreCompleto).HasColumnName("nombre_completo");
            builder.Property(t => t.DocumentoIdentidad).HasColumnName("documento_identidad");
            builder.Property(t => t.Email).HasColumnName("email");
            builder.Property(t => t.Telefono).HasColumnName("telefono");
            builder.Property(t => t.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(t => t.Estado).HasColumnName("estado");
        }
    }
}

