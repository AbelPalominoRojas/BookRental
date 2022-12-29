using System;
using Domain;
using Infrastructure.Base;

namespace Infrastructure.Repositories.Abstractions
{
    public interface IPrestamoDetalleRepository : IRepositoryCrud<PrestamoDetalle, PrestamoDetalleId>, IRepositoryPaginated<PrestamoDetalle>
    {
    }
}

