using System;
using Application.Dtos.Solicitantes;
using Application.Services.Abstractions;
using AutoMapper;
using Domain;
using Infrastructure.Repositories.Abstractions;
using Utils.Paginations;

namespace Application.Services.Implementations
{
	public class SolicitanteService : ISolicitanteService
    {
        private readonly IMapper _mapper;
        private readonly ISolicitanteRepository _solicitanteRepository;

        public SolicitanteService(IMapper mapper, ISolicitanteRepository solicitanteRepository)
        {
            _mapper = mapper;
            _solicitanteRepository = solicitanteRepository;
        }

        public async Task<SolicitanteDto> Create(SolicitanteFormDto dtoForm)
        {
            var entity = _mapper.Map<Solicitante>(dtoForm);
            var response = await _solicitanteRepository.Create(entity);

            return _mapper.Map<SolicitanteDto>(response);
        }

        public async Task<SolicitanteDto> Edit(int id, SolicitanteFormDto dtoForm)
        {
            var entity = _mapper.Map<Solicitante>(dtoForm);
            var response = await _solicitanteRepository.Edit(id, entity);

            return _mapper.Map<SolicitanteDto>(response);
        }

        public async Task<SolicitanteDto?> EnableOrDisable(int id)
        {
            var response = await _solicitanteRepository.EnableOrDisable(id);

            return _mapper.Map<SolicitanteDto>(response);
        }

        public async Task<SolicitanteDto?> Find(int id)
        {
            var response = await _solicitanteRepository.Find(id);

            return _mapper.Map<SolicitanteDto>(response);
        }

        public async Task<IList<SolicitanteDto>> FindAll()
        {
            var response = await _solicitanteRepository.FindAll();

            return _mapper.Map<IList<SolicitanteDto>>(response);
        }

        public async Task<ResponsePagination<SolicitanteDto>> PaginatedSearch(RequestPagination<SolicitanteDto> dto)
        {
            var entity = _mapper.Map<RequestPagination<Solicitante>>(dto);
            var response = await _solicitanteRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<SolicitanteDto>>(response);
        }
    }
}

