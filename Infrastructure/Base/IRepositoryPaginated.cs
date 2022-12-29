using System;
using Utils.Paginations;
namespace Infrastructure.Base
{
	public interface IRepositoryPaginated<T>
	{
		Task<ResponsePagination<T>> PaginatedSearch(RequestPagination<T> entity);
	}
}

