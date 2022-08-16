using LeaveManagement.Application.Contracts;
using LeaveManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Application.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        protected DbSet<T> _entity => _dbContext.Set<T>();

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _entity.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task AddRangeAsync(List<T> entities)
        {
            await _entity.AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var foundRecord = await GetAsync(id);
            _entity.Remove(foundRecord);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await GetAsync(id);
            return entity is not null;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _entity.ToListAsync();
        }

        public async Task<T> GetAsync(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return await _entity.FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            //_entity.Update(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;  
            await _dbContext.SaveChangesAsync();
        }
    }
}
