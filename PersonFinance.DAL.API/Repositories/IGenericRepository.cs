namespace PersonFinance.API.DAL.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        public IQueryable<TEntity> Get();
        public Task<TEntity> AddAsync(TEntity item);
        public TEntity Update(TEntity item);
        public void Remove(TEntity entity);
        public void RemoveRange(IQueryable<TEntity> entities);
        public Task SaveChangesAsync();
    }
}