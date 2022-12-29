using System;
using Application.Dtos.Prestamos;
using Application.Services.Abstractions;
using AutoMapper;
using Domain;
using Infrastructure.Repositories.Abstractions;
using Utils.Paginations;

namespace Application.Services.Implementations
{
	public class PrestamoService : IPrestamoService
    {
        private readonly IMapper _mapper;
        private readonly IPrestamoRepository _prestamoRepository;

        public PrestamoService(IMapper mapper, IPrestamoRepository prestamoRepository)
        {
            _mapper = mapper;
            _prestamoRepository = prestamoRepository;
        }

        public async Task<PrestamoDto> Create(PrestamoFormDto dtoForm)
        {
            var entity = _mapper.Map<Prestamo>(dtoForm);
            var response = await _prestamoRepository.Create(entity);

            return _mapper.Map<PrestamoDto>(response);
        }

        public async Task<PrestamoDto> Edit(int id, PrestamoFormDto dtoForm)
        {
            var entity = _mapper.Map<Prestamo>(dtoForm);
            var response = await _prestamoRepository.Create(entity);

            return _mapper.Map<PrestamoDto>(response);
        }

        public async Task<PrestamoDto?> EnableOrDisable(int id)
        {
            var response = await _prestamoRepository.EnableOrDisable(id);

            return _mapper.Map<PrestamoDto>(response);
        }

        public async Task<PrestamoDto?> Find(int id)
        {
            var response = await _prestamoRepository.Find(id);

            return _mapper.Map<PrestamoDto>(response);
        }

        public async Task<IList<PrestamoDto>> FindAll()
        {
            var response = await _prestamoRepository.FindAll();

            return _mapper.Map<IList<PrestamoDto>>(response);
        }

        public async Task<ResponsePagination<PrestamoDto>> PaginatedSearch(RequestPagination<PrestamoDto> dto)
        {
            var entity = _mapper.Map<RequestPagination<Prestamo>>(dto);
            var response = await _prestamoRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<PrestamoDto>>(response);
        }
    }
}


