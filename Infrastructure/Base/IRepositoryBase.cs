using System;
namespace Infrastructure.Base
{
    public interface IRepositoryBase<T, K>
    {
        Task<T> Create(T entity);
        Task<T?> Find(K id);
        Task<IList<T>> FindAll();
    }
}

