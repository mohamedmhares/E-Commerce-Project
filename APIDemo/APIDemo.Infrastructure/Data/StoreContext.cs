using APIDemo.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace APIDemo.Infrastructure
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }
        
       public DbSet<Product> products { get; set; }
       public DbSet<ProductBrand> productBrands { get; set; }
       public DbSet<ProductType> productTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
