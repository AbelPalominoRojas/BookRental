using System;
using Domain;
using Infrastructure.Context;
using Infrastructure.Core.Paginations.Abstractions;
using Infrastructure.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using Utils.Paginations;

namespace Infrastructure.Repositories.Implementations
{
    public class PrestamoDetalleRepository : IPrestamoDetalleRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<PrestamoDetalle> _paginator;


        public PrestamoDetalleRepository(ApplicationDbContext context, IPaginator<PrestamoDetalle> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<PrestamoDetalle> Create(PrestamoDetalle entity)
        {
            _context.PrestamoDetalles.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<PrestamoDetalle?> Edit(PrestamoDetalleId id, PrestamoDetalle entity)
        {
            var model = await _context.PrestamoDetalles
                .FirstOrDefaultAsync(e => e.IdPrestamo == id.IdPrestamo && e.IdLibro == id.IdLibro);

            if (model != null)
            {
                model.Devuelto = entity.Devuelto;
                model.Mora = entity.Mora;

                _context.PrestamoDetalles.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<PrestamoDetalle?> EnableOrDisable(PrestamoDetalleId id)
        {
            var model = await _context.PrestamoDetalles
                .FirstOrDefaultAsync(e => e.IdPrestamo == id.IdPrestamo && e.IdLibro == id.IdLibro);

            if (model != null)
            {
                model.Estado = (model.Estado == 0) ? 1 : 0;

                _context.PrestamoDetalles.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<PrestamoDetalle?> Find(PrestamoDetalleId id)
        => await _context.PrestamoDetalles.Include(e => e.Libro)
            .FirstOrDefaultAsync(e => e.IdPrestamo == id.IdPrestamo && e.IdLibro == id.IdLibro);

        public async Task<IList<PrestamoDetalle>> FindAll()
        => await _context.PrestamoDetalles.OrderByDescending(e =>e.IdPrestamo).ToListAsync();

        public async Task<ResponsePagination<PrestamoDetalle>> PaginatedSearch(RequestPagination<PrestamoDetalle> entity)
        {
            var filter = entity.Filter;
            var query = _context.PrestamoDetalles.Include(e => e.Libro).AsQueryable();

            if (filter != null)
            {
                query = query.Where(e =>
                    (!filter.Estado.HasValue || e.Estado == filter.Estado)
                    && (!filter.Devuelto.HasValue || e.Devuelto == filter.Devuelto)
                    && (!filter.Mora.HasValue || e.Mora == filter.Mora)
                );
            }

            var response = await _paginator.Paginate(query, entity);

            return response;
        }
    }
}

