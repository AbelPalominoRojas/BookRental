﻿using System;
using Domain;
using Infrastructure.Context;
using Infrastructure.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using Utils.Paginations;
using Infrastructure.Core.Paginations.Abstractions;

namespace Infrastructure.Repositories.Implementations
{
    public class EditorialRepository : IEditorialRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<Editorial> _paginator;

        public EditorialRepository(ApplicationDbContext context, IPaginator<Editorial> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<Editorial> Create(Editorial entity)
        {
            _context.Editoriales.Add(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Editorial?> Edit(int id, Editorial entity)
        {
            var model = await _context.Editoriales.FindAsync(id);

            if (model != null)
            {
                model.Codigo = entity.Codigo;
                model.Nombre = entity.Nombre;

                _context.Editoriales.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<Editorial?> EnableOrDisable(int id)
        {
            var model = await _context.Editoriales.FindAsync(id);

            if (model != null)
            {
                model.Estado = (model.Estado == 0) ? 1 : 0;

                _context.Editoriales.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<Editorial?> Find(int id)
        => await _context.Editoriales.FindAsync(id);

        public async Task<IList<Editorial>> FindAll()
        => await _context.Editoriales.OrderByDescending(e => e.Id).ToListAsync();

        public async Task<ResponsePagination<Editorial>> PaginatedSearch(RequestPagination<Editorial> entity)
        {
            var filter = entity.Filter;
            var query = _context.Editoriales.AsQueryable();

            if (filter != null)
            {
                query = query.Where(e =>
                    (!filter.Estado.HasValue || e.Estado == filter.Estado)
                    && (string.IsNullOrWhiteSpace(filter.Codigo) || e.Codigo.ToUpper().Contains(filter.Codigo.ToUpper().Trim()))
                    && (string.IsNullOrWhiteSpace(filter.Nombre) || e.Nombre.ToUpper().Contains(filter.Nombre.ToUpper().Trim()))
                );
            }

            query = query.OrderByDescending(e => e.Id);

            var response = await _paginator.Paginate(query, entity);

            return response;
        }
    }
}

