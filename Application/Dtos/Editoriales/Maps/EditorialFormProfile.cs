using System;
using AutoMapper;
using Domain;

namespace Application.Dtos.Editoriales.Maps
{
	public class EditorialFormProfile : Profile
	{
		public EditorialFormProfile()
		{
			CreateMap<EditorialFormDto, Editorial>();
		}
	}
}

