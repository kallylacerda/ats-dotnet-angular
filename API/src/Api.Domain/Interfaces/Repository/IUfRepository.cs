using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Repository
{
    public interface IUfRepository
    {
        Task<UfEntity> SelectAsync(byte id);
        Task<IEnumerable<UfEntity>> SelectAsync();
    }
}
