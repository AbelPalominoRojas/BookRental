using System;
namespace Application.Base
{
    public interface IServiceBase<TDto, TFormDto, K>
    {
        Task<TDto> Create(TFormDto dto);
        Task<TDto?> Edit(K id, TFormDto dto);
        Task<TDto?> EnableOrDisable(K id);
        Task<TDto?> Find(K id);
        Task<IList<TDto>> FindAll();
    }
}

