using System;
using Domain;
using Infrastructure.Context;
using Infrastructure.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Implementations
{
    public class LibroRepository : ILibroRepository
    {
        private readonly ApplicationDbContext _context;

        public LibroRepository(ApplicationDbContext context)
        {
            _context = context;
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
    }
}

