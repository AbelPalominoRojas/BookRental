using System;
using Utils.Paginations;
namespace Infrastructure.Core.Paginations.Abstractions
{
	public interface IPaginator<T>
	{
		Task<ResponsePagination<T>> Paginate(IQueryable<T> query, RequestPagination<T> request);
	}
}

