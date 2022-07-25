using Common.Repository;
using CustomerMicroservice.DataAccess.Entities;

namespace CustomerMicroservice.DataAccess.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
    }
}
