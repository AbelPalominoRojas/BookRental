using System;
using Domain;
using Infrastructure.Context;
using Infrastructure.Core.Paginations.Abstractions;
using Infrastructure.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using Utils.Paginations;

namespace Infrastructure.Repositories.Implementations
{
    public class PrestamoRepository : IPrestamoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<Prestamo> _paginator;


        public PrestamoRepository(ApplicationDbContext context, IPaginator<Prestamo> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<Prestamo> Create(Prestamo entity)
        {
            _context.Prestamos.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Prestamo?> Edit(int id, Prestamo entity)
        {
            var model = await _context.Prestamos.FindAsync(id);

            if (model != null)
            {
                model.FechaPrestamo = entity.FechaPrestamo;
                model.FechaDevolucion = entity.FechaDevolucion;
                model.EstadoPrestamo = entity.EstadoPrestamo;
                model.IdSolicitante = entity.IdSolicitante;

                _context.Prestamos.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<Prestamo?> EnableOrDisable(int id)
        {
            var model = await _context.Prestamos.FindAsync(id);

            if (model != null)
            {
                model.Estado = (model.Estado == 0) ? 1 : 0;

                _context.Prestamos.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<Prestamo?> Find(int id)
        => await _context.Prestamos.Include(e => e.Solicitante).FirstOrDefaultAsync(e => e.Id == id);

        public async Task<IList<Prestamo>> FindAll()
        => await _context.Prestamos.OrderByDescending(e => e.Id).ToListAsync();

        public async Task<ResponsePagination<Prestamo>> PaginatedSearch(RequestPagination<Prestamo> entity)
        {
            var filter = entity.Filter;
            var query = _context.Prestamos.Include(e => e.Solicitante).AsQueryable();

            if (filter != null)
            {
                query = query.Where(e =>
                    (!filter.Estado.HasValue || e.Estado == filter.Estado)
                    && (!filter.IdSolicitante.HasValue || e.IdSolicitante == filter.IdSolicitante)
                    && (!filter.EstadoPrestamo.HasValue || e.EstadoPrestamo == filter.EstadoPrestamo)
                );
            }

            query = query.OrderByDescending(e => e.Id);

            var response = await _paginator.Paginate(query, entity);
            return response;
        }
    }
}

