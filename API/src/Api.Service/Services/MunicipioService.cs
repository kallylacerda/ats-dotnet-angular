using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Interfaces.Repository;
using Api.Domain.Interfaces.Services.Municipio;
using AutoMapper;

namespace Api.Service.Services
{
    public class MunicipioService : IMunicipioService
    {
        private IMunicipioRepository _repository;

        private readonly IMapper _mapper;

        public MunicipioService(IMunicipioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<MunicipioDtoCompleto> Get(ushort id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<MunicipioDtoCompleto>(entity);
        }

        public async Task<IEnumerable<MunicipioDto>> GetByUfId(byte ufId)
        {
            var listEntity = await _repository.SelectByUfIdAsync(ufId);
            return _mapper.Map<IEnumerable<MunicipioDto>>(listEntity);
        }

        public async Task<IEnumerable<MunicipioDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<MunicipioDto>>(listEntity);
        }
    }
}
