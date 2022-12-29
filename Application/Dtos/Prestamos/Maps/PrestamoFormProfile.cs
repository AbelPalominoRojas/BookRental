using System;
using Application.Dtos.Prestamos.Maps.Actions;
using AutoMapper;
using Domain;

namespace Application.Dtos.Prestamos.Maps
{
	public class PrestamoFormProfile : Profile
    {
        public PrestamoFormProfile()
        {
            CreateMap<Prestamo, PrestamoFormDto>()
                .AfterMap<PrestamoFormMapAction>();

            CreateMap<PrestamoFormDto, Prestamo>()
                .AfterMap<PrestamoFormReverseMapAction>();
        }
    }
}

