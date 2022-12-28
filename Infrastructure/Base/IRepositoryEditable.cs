using System;
namespace Infrastructure.Base
{
	public interface IRepositoryEditable<T, K>
    {
        Task<T?> Edit(K id, T entity);
        Task<T?> EnableOrDisable(K id);
    }
}

