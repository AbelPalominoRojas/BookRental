using System;
using Application.Dtos.Libros;
using Application.Services.Abstractions;
using AutoMapper;
using Domain;
using Infrastructure.Repositories.Abstractions;

namespace Application.Services.Implementations
{
    public class LibroService : ILibroService
    {

        private readonly IMapper _mapper;
        private readonly ILibroRepository _libroRepository;

        public LibroService(IMapper mapper, ILibroRepository libroRepository)
        {
            _mapper = mapper;
            _libroRepository = libroRepository;
        }

        public async Task<LibroDto> Create(LibroFormDto dto)
        {
            var entity = _mapper.Map<Libro>(dto);
            var response = await _libroRepository.Create(entity);

            return _mapper.Map<LibroDto>(response);
        }

        public async Task<LibroDto?> Edit(int id, LibroFormDto dto)
        {
            var entity = _mapper.Map<Libro>(dto);
            var response = await _libroRepository.Edit(id, entity);

            return _mapper.Map<LibroDto>(response);
        }

        public async Task<LibroDto?> EnableOrDisable(int id)
        {
            var response = await _libroRepository.EnableOrDisable(id);

            return _mapper.Map<LibroDto>(response);
        }

        public async Task<LibroDto?> Find(int id)
        {
            var response = await _libroRepository.Find(id);

            return _mapper.Map<LibroDto>(response);
        }

        public async Task<IList<LibroDto>> FindAll()
        {
            var response = await _libroRepository.FindAll();

            return _mapper.Map<IList<LibroDto>>(response);
        }
    }
}

