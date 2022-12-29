using System;
namespace Application.Dtos.PrestamoDetalles
{
    public class PrestamoDetalleDto
    {
        public int IdPrestamo { get; set; }
        public int IdLibro { get; set; }
        public int? Devuelto { get; set; }
        public decimal? Mora { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int? Estado { get; set; }
    }

}