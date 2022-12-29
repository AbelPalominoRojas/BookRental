using System;
using Application.Base;
using Application.Dtos.Prestamos;

namespace Application.Services.Abstractions
{
	public interface IPrestamoService : IServiceBase<PrestamoDto, PrestamoFormDto, int>, IServicePaginated<PrestamoDto>
    {
	}
}

