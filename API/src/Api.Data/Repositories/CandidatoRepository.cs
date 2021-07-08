using System;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repositories
{
  public class CandidatoRepository : BaseRepository<CandidatoEntity>, ICandidatoRepository
  {
    private DbSet<CandidatoEntity> _dataset;
    public CandidatoRepository(MyContext context) : base(context)
    {
      _dataset = _context.Set<CandidatoEntity>();
    }

    public async Task<CandidatoEntity> SelecWithEnderecoAsync(Guid id)
    {
      try
      {
        return await _dataset.Include(c => c.Endereco)
                            .ThenInclude(e => e.Municipio)
                            .ThenInclude(m => m.Uf)
                            .SingleOrDefaultAsync(p => p.Id.Equals(id));
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task<CandidatoEntity> UpdateCandidatoAsync(CandidatoEntity candidado)
    {
      try
      {

        var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(candidado.Id));

        if (result == null)
          return null;

        candidado.Cpf = result.Cpf;
        candidado.UpdatedAt = DateTime.UtcNow;
        candidado.CreatedAt = result.CreatedAt;

        _context.Entry(result).CurrentValues.SetValues(candidado);
        await _context.SaveChangesAsync();
      }
      catch (Exception ex)
      {
        throw ex;
      }

      return candidado;
    }
  }
}
