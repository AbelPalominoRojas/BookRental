using System;
using AutoMapper;
using Domain;
using Utils.Paginations;

namespace Application.Dtos.Editoriales.Maps
{
	public class EditorialProfile: Profile
	{
		public EditorialProfile()
		{
			CreateMap<Editorial, EditorialDto>();

			CreateMap<EditorialDto, Editorial>();

			CreateMap<RequestPagination<EditorialDto>, RequestPagination<Editorial>>();

			CreateMap<ResponsePagination<Editorial>, ResponsePagination<EditorialDto>>();
		}
	}
}

