using System;
using Utils.Paginations;
namespace Application.Base
{
	public interface IServicePaginated<TDto>
	{
		Task<ResponsePagination<TDto>> PaginatedSearch(RequestPagination<TDto> dto);
    }
}

