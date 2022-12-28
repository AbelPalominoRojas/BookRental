using System;
using Application.Base;
using Application.Dtos.Editoriales;

namespace Application.Services.Abstractions
{
    public interface IEditorialService : IServiceBase<EditorialDto, EditorialFormDto, int>
    {
    }
}

