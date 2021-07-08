using System;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Repository
{
    public interface ICandidatoRepository : IRepository<CandidatoEntity>
    {
        Task<CandidatoEntity> SelecWithEnderecoAsync(Guid id);
        Task<CandidatoEntity> UpdateCandidatoAsync(CandidatoEntity candidado);
    }
}
