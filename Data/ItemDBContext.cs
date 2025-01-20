using AzurePublishingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AzurePublishingAPI.Data
{
    public class ItemDBContext : DbContext
    {

        public DbSet<Item> Items { get; set; }

        public ItemDBContext(DbContextOptions<ItemDBContext> options) : base(options)
        {
        }
    }
}
