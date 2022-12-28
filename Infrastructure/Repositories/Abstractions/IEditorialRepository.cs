using System;
using Domain;

namespace Infrastructure.Repositories.Abstractions
{
	public interface IEditorialRepository
	{
		Task<Editorial> Create(Editorial entity);
		Task<Editorial?> Edit(int id, Editorial entity);
		Task<Editorial?> EnableOrDisable(int id);
		Task<Editorial?> Find(int id);
		Task<IList<Editorial>> FindAll();
	}
}

