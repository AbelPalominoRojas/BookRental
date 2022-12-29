using System;
using AutoMapper;
using Domain;
using Utils.Paginations;

namespace Application.Dtos.Solicitantes.Maps
{
	public class SolicitanteProfile : Profile
	{
		public SolicitanteProfile()
		{
			CreateMap<Solicitante, SolicitanteDto>();

            CreateMap<SolicitanteDto, Solicitante>();

            CreateMap<RequestPagination<SolicitanteDto>, RequestPagination<Solicitante>>();

            CreateMap<ResponsePagination<Solicitante>, ResponsePagination<SolicitanteDto>>();
        }
    }
}

