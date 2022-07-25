using Microsoft.EntityFrameworkCore;
using OrderMicroservice.DataAccess.Entities;

namespace OrderMicroservice.DataAccess
{
    public class ViewContext : DbContext
    {
        public ViewContext(DbContextOptions<ViewContext> options)
      : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<OrderView> OrderViews { get; set; } = null!;
        public DbSet<ProductView> ProductViews { get; set; } = null!;
        public DbSet<CustomerView> CustomerViews { get; set; } = null!;

    }
}
