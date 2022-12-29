using System;
using Domain;
using Infrastructure.Context;
using Infrastructure.Core.Paginations.Abstractions;
using Infrastructure.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using Utils.Paginations;

namespace Infrastructure.Repositories.Implementations
{
    public class SolicitanteRepository : ISolicitanteRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<Solicitante> _paginator;

        public SolicitanteRepository(ApplicationDbContext context, IPaginator<Solicitante> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<Solicitante> Create(Solicitante entity)
        {
            _context.Solicitantes.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Solicitante?> Edit(int id, Solicitante entity)
        {
            var model = await _context.Solicitantes.FindAsync(id);

            if (model != null)
            {
                model.NombreCompleto = entity.NombreCompleto;
                model.DocumentoIdentidad = entity.DocumentoIdentidad;
                model.Email = entity.Email;
                model.Telefono = entity.Telefono;

                _context.Solicitantes.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<Solicitante?> EnableOrDisable(int id)
        {
            var model = await _context.Solicitantes.FindAsync(id);

            if (model != null)
            {
                model.Estado = (model.Estado == 0) ? 1 : 0;

                _context.Solicitantes.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<Solicitante?> Find(int id)
        => await _context.Solicitantes.FindAsync(id);

        public async Task<IList<Solicitante>> FindAll()
        => await _context.Solicitantes.OrderByDescending(e => e.Id).ToListAsync();

        public async Task<ResponsePagination<Solicitante>> PaginatedSearch(RequestPagination<Solicitante> entity)
        {
            var filter = entity.Filter;
            var query = _context.Solicitantes.AsQueryable();

            if (filter != null)
            {
                query = query.Where(e =>
                    (!filter.Estado.HasValue || e.Estado == filter.Estado)
                    && (string.IsNullOrWhiteSpace(filter.NombreCompleto) || e.NombreCompleto.ToUpper().Contains(filter.NombreCompleto.ToUpper().Trim()))
                    && (string.IsNullOrWhiteSpace(filter.DocumentoIdentidad) || e.DocumentoIdentidad.ToUpper().Contains(filter.DocumentoIdentidad.ToUpper().Trim()))
                    && (string.IsNullOrWhiteSpace(filter.Email) || e.Email.ToUpper().Contains(filter.Email.ToUpper().Trim()))
                    && (string.IsNullOrWhiteSpace(filter.Telefono) || e.Telefono.ToUpper().Contains(filter.Telefono.ToUpper().Trim()))
                );
            }

            query = query.OrderByDescending(e => e.Id);

            var response = await _paginator.Paginate(query, entity);
            return response;
        }
    }
}

