using Microsoft.EntityFrameworkCore;

namespace PersonFinance.API.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly PersonFinanceContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(PersonFinanceContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public IQueryable<TEntity> Get()
        {
            return _dbSet.AsNoTracking();
        }

        public async Task<TEntity> AddAsync(TEntity item)
        {
            return (await _dbSet.AddAsync(item)).Entity;
        }
        public TEntity Update(TEntity item)
        {
            var updatedEntity = _dbSet.Update(item);

            return updatedEntity.Entity;
        }
        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
        public void RemoveRange(IQueryable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task SaveChangesAsync()
        {
             await _context.SaveChangesAsync();
        }
    }
}
