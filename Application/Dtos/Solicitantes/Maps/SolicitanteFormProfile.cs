using System;
using AutoMapper;
using Domain;

namespace Application.Dtos.Solicitantes.Maps
{
	public class SolicitanteFormProfile: Profile
	{
		public SolicitanteFormProfile()
		{
			CreateMap<Solicitante, SolicitanteFormDto>();

            CreateMap<SolicitanteFormDto, Solicitante>();
        }
    }
}

