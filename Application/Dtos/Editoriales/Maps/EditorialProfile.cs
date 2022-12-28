using System;
using AutoMapper;
using Domain;

namespace Application.Dtos.Editoriales.Maps
{
	public class EditorialProfile: Profile
	{
		public EditorialProfile()
		{
			CreateMap<Editorial, EditorialDto>();
		}
	}
}

