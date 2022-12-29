using System;
using Application.Base;
using Application.Dtos.PrestamoDetalles;

namespace Application.Services.Abstractions
{
	public interface IPrestamoDetalleService : IServiceBase<PrestamoDetalleDto, PrestamoDetalleFormDto, PrestamoDetalleIdDto>, IServicePaginated<PrestamoDetalleDto>
    {
	}
}

