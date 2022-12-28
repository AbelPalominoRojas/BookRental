using System;
using AutoMapper;
using Domain;

namespace Application.Dtos.Libros.Maps
{
	public class LibroProfile : Profile
	{
		public LibroProfile()
		{
			CreateMap<Libro, LibroDto>();
		}
	}
}

