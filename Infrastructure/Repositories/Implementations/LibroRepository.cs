using System;
using Domain;
using Infrastructure.Context;
using Infrastructure.Core.Paginations.Abstractions;
using Infrastructure.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using Utils.Paginations;

namespace Infrastructure.Repositories.Implementations
{
    public class LibroRepository : ILibroRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<Libro> _paginator;

        public LibroRepository(ApplicationDbContext context, IPaginator<Libro> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<Libro> Create(Libro entity)
        {
            _context.Libros.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Libro?> Edit(int id, Libro entity)
        {
            var model = await _context.Libros.FindAsync(id);

            if (model != null)
            {
                model.Isbn = entity.Isbn;
                model.Titulo = entity.Titulo;
                model.Autores = entity.Autores;
                model.Edicion = entity.Edicion;
                model.Anio = entity.Anio;
                model.IdEditorial = entity.IdEditorial;

                _context.Libros.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<Libro?> EnableOrDisable(int id)
        {
            var model = await _context.Libros.FindAsync(id);

            if (model != null)
            {
                model.Estado = (model.Estado == 0) ? 1 : 0;

                _context.Libros.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<Libro?> Find(int id)
        => await _context.Libros.Include(e => e.Editorial).FirstOrDefaultAsync(e => e.Id == id);

        public async Task<IList<Libro>> FindAll()
        => await _context.Libros.Include(e => e.Editorial).OrderByDescending(e => e.Id).ToListAsync();

        public async Task<ResponsePagination<Libro>> PaginatedSearch(RequestPagination<Libro> entity)
        {
            var filter = entity.Filter;
            var query = _context.Libros.Include(e => e.Editorial).AsQueryable();

            if (filter != null)
            {
                query = query.Where(e =>
                    (!filter.Estado.HasValue || e.Estado == filter.Estado)
                    && (string.IsNullOrWhiteSpace(filter.Isbn) || e.Isbn.ToUpper().Contains(filter.Isbn.ToUpper().Trim()))
                    && (string.IsNullOrWhiteSpace(filter.Titulo) || e.Titulo.ToUpper().Contains(filter.Titulo.ToUpper().Trim()))
                    && (string.IsNullOrWhiteSpace(filter.Autores) || e.Autores.ToUpper().Contains(filter.Autores.ToUpper().Trim()))
                    && (string.IsNullOrWhiteSpace(filter.Edicion) || e.Edicion.ToUpper().Contains(filter.Edicion.ToUpper().Trim()))
                    && (!filter.Anio.HasValue || e.Anio == filter.Anio)
                    && (!filter.IdEditorial.HasValue || e.IdEditorial == filter.IdEditorial)
                );
            }

            query = query.OrderByDescending(e => e.Id);

            var response = await _paginator.Paginate(query, entity);
            return response;
        }
    }
}

