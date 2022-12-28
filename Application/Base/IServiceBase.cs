using System;
namespace Application.Base
{
    public interface IServiceBase<TDto, TFormDto, K>
    {
        Task<TDto> Create(TFormDto dto);
        Task<TDto?> Edit(int id, TFormDto dto);
        Task<TDto?> EnableOrDisable(int id);
        Task<TDto?> Find(int id);
        Task<IList<TDto>> FindAll();
    }
}

