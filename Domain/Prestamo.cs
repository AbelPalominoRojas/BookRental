using System;
namespace Domain
{
	public class Prestamo
	{
        public int Id { get; set; }
        public DateTime FechaPrestamo { get; set; } = DateTime.UtcNow;
        public DateTime? FechaDevolucion { get; set; }
        public int? EstadoPrestamo { get; set; }
        public int? IdSolicitante { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public int? Estado { get; set; } = 1;

        public virtual Solicitante Solicitante { get; set; }
    }
}

