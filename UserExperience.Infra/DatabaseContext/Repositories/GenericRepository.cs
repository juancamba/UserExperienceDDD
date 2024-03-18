using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserExperience.Application.Contracts.Persistence;

namespace UserExperience.Infra.Persistence.DatabaseContext.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly WEDatabaseContext _context;
        public GenericRepository(WEDatabaseContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }

    }
}
