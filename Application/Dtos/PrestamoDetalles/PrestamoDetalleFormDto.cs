using System;
namespace Application.Dtos.PrestamoDetalles
{
	public class PrestamoDetalleFormDto
	{
        public int IdPrestamo { get; set; }
        public int IdLibro { get; set; }
        public int? Devuelto { get; set; }
        public decimal? Mora { get; set; }
    }
}

