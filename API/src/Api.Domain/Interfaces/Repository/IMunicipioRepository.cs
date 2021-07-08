using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Repository
{
    public interface IMunicipioRepository
    {
        Task<MunicipioEntity> SelectAsync(ushort id);
        Task<IEnumerable<MunicipioEntity>> SelectByUfIdAsync(byte ufId);
        Task<IEnumerable<MunicipioEntity>> SelectAsync();
    }
}
