using Microsoft.EntityFrameworkCore;
using OrderMicroservice.DataAccess.Entities;

namespace OrderMicroservice.DataAccess
{
    public class OrderCommandContext : DbContext
    {
        public OrderCommandContext(DbContextOptions<OrderCommandContext> options)
       : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Order> Orders { get; set; } = null!;

    }
}
