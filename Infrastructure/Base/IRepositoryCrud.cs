using System;
namespace Infrastructure.Base
{
	public interface IRepositoryCrud<T, K> : IRepositoryBase<T, K>, IRepositoryEditable<T, K>
    {
	}
}

