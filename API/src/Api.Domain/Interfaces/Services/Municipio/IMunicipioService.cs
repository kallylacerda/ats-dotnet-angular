using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Municipio;

namespace Api.Domain.Interfaces.Services.Municipio
{
    public interface IMunicipioService
    {
        Task<MunicipioDtoCompleto> Get(ushort id);
        Task<IEnumerable<MunicipioDto>> GetByUfId(byte ufId);
        Task<IEnumerable<MunicipioDto>> GetAll();
    }
}
