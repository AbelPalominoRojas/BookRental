using System;
using Application.Dtos.Solicitantes;

namespace Application.Dtos.Prestamos
{
	public class PrestamoFormDto
	{
        public DateTime FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public int? EstadoPrestamo { get; set; }

        public virtual SolicitanteDto Solicitante { get; set; }
    }
}

