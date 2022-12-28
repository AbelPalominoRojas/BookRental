using System;
namespace Domain
{
    public class Editorial
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public int Estado { get; set; } = 1;
    }
}

