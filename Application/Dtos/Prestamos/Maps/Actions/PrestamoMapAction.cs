using System;
using Application.Dtos.Solicitantes;
using AutoMapper;
using Domain;

namespace Application.Dtos.Prestamos.Maps.Actions
{
	public class PrestamoMapAction : IMappingAction<Prestamo, PrestamoDto>
    {
        public void Process(Prestamo source, PrestamoDto destination, ResolutionContext context)
        {
            if (source.Solicitante != null) destination.Solicitante = context.Mapper.Map<SolicitanteDto>(source.Solicitante);
        }
    }
}

