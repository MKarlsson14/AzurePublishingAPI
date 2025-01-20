using Microsoft.EntityFrameworkCore;

namespace AzurePublishingAPI.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ItemDBContext dbContext;

        public Repository(ItemDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await dbContext.Set<TEntity>().ToListAsync();
        }
    }
}
