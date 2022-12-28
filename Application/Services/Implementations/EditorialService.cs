using Application.Dtos.Editoriales;
using Application.Services.Abstractions;
using AutoMapper;
using Domain;
using Infrastructure.Repositories.Abstractions;

namespace Application.Services.Implementations
{
    public class EditorialService : IEditorialService
    {
        private readonly IMapper _mapper;
        private readonly IEditorialRepository _editorialRepository;

        public EditorialService(IMapper mapper, IEditorialRepository editorialRepository)
        {
            _mapper = mapper;
            _editorialRepository = editorialRepository;
        }

        public async Task<EditorialDto> Create(EditorialFormDto dto)
        {
            var entity = _mapper.Map<Editorial>(dto);
            var response = await _editorialRepository.Create(entity);

            return _mapper.Map<EditorialDto>(response);
        }

        public async Task<EditorialDto?> Edit(int id, EditorialFormDto dto)
        {
            var entity = _mapper.Map<Editorial>(dto);
            var response = await _editorialRepository.Edit(id, entity);

            return _mapper.Map<EditorialDto>(response);
        }

        public async Task<EditorialDto?> EnableOrDisable(int id)
        {
            var response = await _editorialRepository.EnableOrDisable(id);

            return _mapper.Map<EditorialDto>(response);
        }

        public async Task<EditorialDto?> Find(int id)
        {
            var response = await _editorialRepository.Find(id);

            return _mapper.Map<EditorialDto>(response);
        }

        public async Task<IList<EditorialDto>> FindAll()
        {
            var response = await _editorialRepository.FindAll();

            return _mapper.Map<IList<EditorialDto>>(response);
        }
    }
}

