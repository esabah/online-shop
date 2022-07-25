using Common.Repository;
using CustomerMicroservice.DataAccess.Entities;

namespace CustomerMicroservice.DataAccess.Repositories
{
    public class CustomerRepository: RepositoryBase<Customer> , ICustomerRepository
    {
        public CustomerRepository(CustomerContext customerContext) : base(customerContext)
        {
        }


    }
}
