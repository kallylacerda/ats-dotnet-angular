using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repositories
{
    public class UfRepository : IUfRepository
    {
        protected readonly MyContext _context;
        private DbSet<UfEntity> _dataset;

        public UfRepository(MyContext context)
        {
            _context = context;
            _dataset = _context.Set<UfEntity>();
        }

        public async Task<UfEntity> SelectAsync(byte id)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<UfEntity>> SelectAsync()
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
    }
}
