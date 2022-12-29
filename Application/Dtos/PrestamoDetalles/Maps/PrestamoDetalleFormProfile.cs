using System;
using AutoMapper;
using Domain;

namespace Application.Dtos.PrestamoDetalles.Maps
{
	public class PrestamoDetalleFormProfile : Profile
	{
		public PrestamoDetalleFormProfile()
		{
			CreateMap<PrestamoDetalle, PrestamoDetalleFormDto>();

			CreateMap<PrestamoDetalle, PrestamoDetalleFormDto>()
				.ReverseMap();
        }
	}
}

