using System;
using Infrastructure.Core.Paginations.Abstractions;
using Microsoft.EntityFrameworkCore;
using Utils.Paginations;

namespace Infrastructure.Core.Paginations.Implementations
{
    public class Paginator<T> : IPaginator<T>
    {
        public async Task<ResponsePagination<T>> Paginate(IQueryable<T> query, RequestPagination<T> request)
        {
            var total = await query.CountAsync();
            var pagination = new Pagination(total, request.Page, request.PerPage);

            var sizePerPage = pagination.PerPage;

            var diference = (pagination.To - pagination.From) + 1;
            if (diference < pagination.PerPage) sizePerPage = diference;

            var currentPage = pagination.CurrentPage;
            if (currentPage > 0) currentPage = pagination.CurrentPage - 1;


            query = query.Skip(currentPage * sizePerPage).Take(sizePerPage);
            var data = await query.ToListAsync();

            var response = new ResponsePagination<T>(pagination)
            {
                Data = data
            };

            return response;
        }
    }
}

