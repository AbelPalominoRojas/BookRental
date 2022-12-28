using System;
using Domain;
using Infrastructure.Context;
using Infrastructure.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Implementations
{
    public class EditorialRepository : IEditorialRepository
    {
        private readonly ApplicationDbContext _context;

        public EditorialRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Editorial>> FindAll()
        => await _context.Editoriales.OrderByDescending(e => e.Id).ToListAsync();
    }
}

