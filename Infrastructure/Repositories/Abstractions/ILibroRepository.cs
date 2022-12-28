using System;
using Domain;
using Infrastructure.Base;

namespace Infrastructure.Repositories.Abstractions
{
    public interface ILibroRepository : IRepositoryCrud<Libro, int>
    {
    }
}

