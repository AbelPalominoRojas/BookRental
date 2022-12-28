using System;
using Domain;

namespace Infrastructure.Repositories.Abstractions
{
	public interface IEditorialRepository
	{
		Task<IList<Editorial>> FindAll();
	}
}

