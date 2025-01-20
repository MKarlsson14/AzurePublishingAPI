namespace AzurePublishingAPI.Data
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public Task<IEnumerable<TEntity>> GetAllAsync();
    }
}