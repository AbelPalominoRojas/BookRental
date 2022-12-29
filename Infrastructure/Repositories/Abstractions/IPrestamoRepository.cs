using System;
using Domain;
using Infrastructure.Base;

namespace Infrastructure.Repositories.Abstractions
{
	public interface IPrestamoRepository : IRepositoryCrud<Prestamo, int>, IRepositoryPaginated<Prestamo>
    {
	}
}

