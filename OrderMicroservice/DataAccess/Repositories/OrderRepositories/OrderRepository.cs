using Common.Repository;
using OrderMicroservice.DataAccess.Entities;

namespace OrderMicroservice.DataAccess.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(OrderCommandContext orderCommandContext) : base(orderCommandContext)
        {
        }
    }
}
