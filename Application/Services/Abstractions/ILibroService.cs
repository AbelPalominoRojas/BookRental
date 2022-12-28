using System;
using Application.Base;
using Application.Dtos.Libros;

namespace Application.Services.Abstractions
{
	public interface ILibroService : IServiceBase<LibroDto, LibroFormDto, int>
    {
	}
}

