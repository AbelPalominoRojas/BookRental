using System;
namespace Application.Dtos.Libros
{
    public class LibroFormDto
    {
        public string Isbn { get; set; }
        public string Titulo { get; set; }
        public string Autores { get; set; }
        public string Edicion { get; set; }
        public int Anio { get; set; }
        public int IdEditorial { get; set; }
    }
}

