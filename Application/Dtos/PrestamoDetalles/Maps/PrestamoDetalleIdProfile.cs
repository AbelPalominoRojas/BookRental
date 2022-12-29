using System;
using AutoMapper;
using Domain;

namespace Application.Dtos.PrestamoDetalles.Maps
{
	public class PrestamoDetalleIdProfile : Profile
	{
		public PrestamoDetalleIdProfile()
		{
			CreateMap<PrestamoDetalleId, PrestamoDetalleIdDto>()
				.ReverseMap();
		}
	}
}

