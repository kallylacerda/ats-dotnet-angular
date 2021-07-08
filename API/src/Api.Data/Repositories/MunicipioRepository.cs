using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repositories
{
    public class MunicipioRepository : IMunicipioRepository
    {
        protected readonly MyContext _context;
        private DbSet<MunicipioEntity> _dataset;

        public MunicipioRepository(MyContext context)
        {
            _context = context;
            _dataset = _context.Set<MunicipioEntity>();
        }

        public async Task<MunicipioEntity> SelectAsync(ushort id)
        {
            try
            {
                return await _dataset.Include(m => m.Uf).SingleOrDefaultAsync(p => p.Id.Equals(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<MunicipioEntity>> SelectAsync()
        {
            try
            {
                return await _dataset.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<MunicipioEntity>> SelectByUfIdAsync(byte ufId)
        {
            try
            {
                return await _dataset.Where(m => m.Uf.Id.Equals(ufId)).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
