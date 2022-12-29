using System;
namespace Application.Dtos.Solicitantes
{
	public class SolicitanteDto : SolicitanteFormDto
    {
        public int Id { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int? Estado { get; set; }
    }
}

