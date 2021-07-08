using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Candidato;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repository;
using Api.Domain.Interfaces.Services.Candidato;
using Api.Domain.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Api.Service.Services
{
    public class CandidatoService : ICandidatoService
    {
        private ICandidatoRepository _repository;

        private readonly IMapper _mapper;

        public CandidatoService(ICandidatoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<CandidatoDtoCompleto> Get(Guid id)
        {
            var entity = await _repository.SelecWithEnderecoAsync(id);
            return _mapper.Map<CandidatoDtoCompleto>(entity);
        }

        public async Task<IEnumerable<CandidatoDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<CandidatoDto>>(listEntity);
        }

        public async Task<CandidatoDtoCreateResult> Post(CandidatoDtoCreate candidato)
        {
            try
            {
                var model = _mapper.Map<CandidatoModel>(candidato);
                var entity = _mapper.Map<CandidatoEntity>(model);
                var result = await _repository.InsertAsync(entity);
                return _mapper.Map<CandidatoDtoCreateResult>(result);
            }
            catch (DbUpdateException dbex)
            {
                throw new ArgumentException(dbex.InnerException.Message);
            }
        }

        public async Task<CandidatoDtoUpdateResult> Put(CandidatoDtoUpdate candidato)
        {
            try
            {
                var model = _mapper.Map<CandidatoModel>(candidato);
                var entity = _mapper.Map<CandidatoEntity>(model);
                var result = await _repository.UpdateCandidatoAsync(entity);
                return _mapper.Map<CandidatoDtoUpdateResult>(result);
            }
            catch (DbUpdateException dbex)
            {
                throw new ArgumentException(dbex.InnerException.Message);
            }
        }
    }
}
