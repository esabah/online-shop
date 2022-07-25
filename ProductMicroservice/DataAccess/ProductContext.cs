using Microsoft.EntityFrameworkCore;
using ProductMicroservice.DataAccess.Entities;

namespace ProductMicroservice.DataAccess
{
    public class ProductContext : DbContext
    {

        public ProductContext(DbContextOptions<ProductContext> options)
      : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;

    }
}
