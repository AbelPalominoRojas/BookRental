using System;
using Application.Dtos.PrestamoDetalles;
using Application.Services.Abstractions;
using AutoMapper;
using Domain;
using Infrastructure.Repositories.Abstractions;
using Utils.Paginations;

namespace Application.Services.Implementations
{
    public class PrestamoDetalleService : IPrestamoDetalleService
    {
        private readonly IMapper _mapper;
        private readonly IPrestamoDetalleRepository _prestamoDetalleRepository;

        public PrestamoDetalleService(IMapper mapper, IPrestamoDetalleRepository prestamoDetalleRepository)
        {
            _mapper = mapper;
            _prestamoDetalleRepository = prestamoDetalleRepository;
        }

        public async Task<PrestamoDetalleDto> Create(PrestamoDetalleFormDto dto)
        {
            var entity = _mapper.Map<PrestamoDetalle>(dto);
            var response = await _prestamoDetalleRepository.Create(entity);

            return _mapper.Map<PrestamoDetalleDto>(response);
        }

        public async Task<PrestamoDetalleDto?> Edit(PrestamoDetalleIdDto id, PrestamoDetalleFormDto dto)
        {
            var idEntity = _mapper.Map<PrestamoDetalleId>(id);
            var entity = _mapper.Map<PrestamoDetalle>(dto);
            var response = await _prestamoDetalleRepository.Edit(idEntity, entity);

            return _mapper.Map<PrestamoDetalleDto>(response);
        }

        public async Task<PrestamoDetalleDto?> EnableOrDisable(PrestamoDetalleIdDto id)
        {
            var idEntity = _mapper.Map<PrestamoDetalleId>(id);
            var response = await _prestamoDetalleRepository.EnableOrDisable(idEntity);

            return _mapper.Map<PrestamoDetalleDto>(response);
        }

        public async Task<PrestamoDetalleDto?> Find(PrestamoDetalleIdDto id)
        {
            var idEntity = _mapper.Map<PrestamoDetalleId>(id);
            var response = await _prestamoDetalleRepository.Find(idEntity);

            return _mapper.Map<PrestamoDetalleDto>(response);
        }

        public async Task<IList<PrestamoDetalleDto>> FindAll()
        {
            var response = await _prestamoDetalleRepository.FindAll();

            return _mapper.Map<IList<PrestamoDetalleDto>>(response);
        }

        public async Task<ResponsePagination<PrestamoDetalleDto>> PaginatedSearch(RequestPagination<PrestamoDetalleDto> dto)
        {
            var entity = _mapper.Map<RequestPagination<PrestamoDetalle>>(dto);
            var response = await _prestamoDetalleRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<PrestamoDetalleDto>>(response);
        }
    }
}

