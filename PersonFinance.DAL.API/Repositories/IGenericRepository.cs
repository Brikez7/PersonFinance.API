using Microsoft.EntityFrameworkCore;

namespace PersonFinance.API.DAL.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        public IQueryable<TEntity> Get();
        public Task Create(TEntity item);
        public void Update(TEntity item);
        public void Remove(TEntity entity);
        public void RemoveRange(IQueryable<TEntity> entities);
    }
}