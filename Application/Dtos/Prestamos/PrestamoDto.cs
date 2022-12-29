using System;
namespace Application.Dtos.Prestamos
{
	public class PrestamoDto : PrestamoFormDto
    {
        public int Id { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int? Estado { get; set; }
    }
}

