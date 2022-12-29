using System;
using Application.Dtos.Solicitantes;
using AutoMapper;
using Domain;

namespace Application.Dtos.Prestamos.Maps.Actions
{
	public class PrestamoFormMapAction : IMappingAction<Prestamo, PrestamoFormDto>
    {
        public void Process(Prestamo source, PrestamoFormDto destination, ResolutionContext context)
        {
            if (source.Solicitante != null) destination.Solicitante = context.Mapper.Map<SolicitanteDto>(source.Solicitante);
        }
    }
}
