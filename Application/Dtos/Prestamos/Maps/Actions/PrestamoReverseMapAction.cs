using System;
using AutoMapper;
using Domain;

namespace Application.Dtos.Prestamos.Maps.Actions
{
	public class PrestamoReverseMapAction : IMappingAction<PrestamoDto, Prestamo>
    {
        public void Process(PrestamoDto source, Prestamo destination, ResolutionContext context)
        {
            if (source.Solicitante != null)
            {
                destination.Solicitante = context.Mapper.Map<Solicitante>(source.Solicitante);
                destination.IdSolicitante = destination.Solicitante.Id;
            }
        }
    }
}

