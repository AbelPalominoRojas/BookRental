using System;
using AutoMapper;
using Domain;

namespace Application.Dtos.Libros.Maps
{
	public class LibroFormProfile : Profile
	{
		public LibroFormProfile()
		{
			CreateMap<LibroFormDto, Libro>();
		}
	}
}

