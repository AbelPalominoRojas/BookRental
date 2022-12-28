using System;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
	public class ApplicationDbContext : DbContext
	{

		public ApplicationDbContext()
		{
		}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

    }
}

