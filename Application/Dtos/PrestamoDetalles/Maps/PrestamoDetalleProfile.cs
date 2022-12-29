using System;
using AutoMapper;
using Domain;
using Utils.Paginations;

namespace Application.Dtos.PrestamoDetalles.Maps
{
    public class PrestamoDetalleProfile : Profile
    {
        public PrestamoDetalleProfile()
        {
            CreateMap<PrestamoDetalle, PrestamoDetalleDto>();

            CreateMap<PrestamoDetalle, PrestamoDetalleDto>()
                .ReverseMap();

            CreateMap<RequestPagination<PrestamoDetalle>, RequestPagination<PrestamoDetalleDto>>()
                .ReverseMap();

            CreateMap<ResponsePagination<PrestamoDetalle>, ResponsePagination<PrestamoDetalleDto>>();
        }
    }
}

