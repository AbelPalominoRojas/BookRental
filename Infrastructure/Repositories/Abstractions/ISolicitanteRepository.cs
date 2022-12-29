using System;
using Domain;
using Infrastructure.Base;

namespace Infrastructure.Repositories.Abstractions
{
	public interface ISolicitanteRepository : IRepositoryCrud<Solicitante, int>, IRepositoryPaginated<Solicitante>
    {
	}
}

