using Common.Repository;
using OrderMicroservice.DataAccess.Entities;

namespace OrderMicroservice.DataAccess.Repositories
{
    public class CustomerViewRepository: RepositoryBase<CustomerView> , ICustomerViewRepository
    {
        public CustomerViewRepository(ViewContext queryContext) : base(queryContext)
        {
        }


    }
}
