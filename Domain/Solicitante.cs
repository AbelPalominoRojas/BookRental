using System;
namespace Domain
{
	public class Solicitante
	{
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string DocumentoIdentidad { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public int? Estado { get; set; } = 1;

        public virtual IList<Prestamo> Prestamos { get; set; }
    }
}

