using CustomerMicroservice.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerMicroservice.DataAccess
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Customer> Customers { get; set; } = null!;
    }
}
