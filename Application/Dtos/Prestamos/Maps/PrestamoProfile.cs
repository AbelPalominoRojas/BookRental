using System;
using Application.Dtos.Prestamos.Maps.Actions;
using AutoMapper;
using Domain;
using Utils.Paginations;

namespace Application.Dtos.Prestamos.Maps
{
	public class PrestamoProfile : Profile
    {
        public PrestamoProfile()
        {
            CreateMap<Prestamo, PrestamoDto>()
                .AfterMap<PrestamoMapAction>();

            CreateMap<PrestamoDto, Prestamo>()
                .AfterMap<PrestamoReverseMapAction>();

            CreateMap<RequestPagination<PrestamoDto>, RequestPagination<Prestamo>>();

            CreateMap<ResponsePagination<Prestamo>, ResponsePagination<PrestamoDto>>();
        }
    }
}