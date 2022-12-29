using System;
namespace Domain
{
	public class PrestamoDetalle
	{
        public int IdPrestamo { get; set; }
        public int IdLibro { get; set; }
        public int? Devuelto { get; set; }
        public decimal? Mora { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public int? Estado { get; set; } = 1;

        public virtual Libro Libro { get; set; }
    }
}

