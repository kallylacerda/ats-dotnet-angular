using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Candidato;

namespace Api.Domain.Interfaces.Services.Candidato
{
    public interface ICandidatoService
    {
        Task<CandidatoDtoCompleto> Get(Guid id);
        Task<IEnumerable<CandidatoDto>> GetAll();
        Task<CandidatoDtoCreateResult> Post(CandidatoDtoCreate candidato);
        Task<CandidatoDtoUpdateResult> Put(CandidatoDtoUpdate candidato);
        Task<bool> Delete(Guid id);
    }
}
