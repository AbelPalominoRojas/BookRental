using System;
using Application.Dtos.Editoriales;

namespace Application.Services.Abstractions
{
	public interface IEditorialService
	{
		Task<IList<EditorialDto>> FindAll();
	}
}

