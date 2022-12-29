using System;
using Application.Base;
using Application.Dtos.Solicitantes;

namespace Application.Services.Abstractions
{
	public interface ISolicitanteService : IServiceBase<SolicitanteDto, SolicitanteFormDto, int>, IServicePaginated<SolicitanteDto>
    {
	}
}

