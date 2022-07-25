using Common.Repository;
using OrderMicroservice.DataAccess.Entities;

namespace OrderMicroservice.DataAccess.Repositories
{
    public interface IOrderViewRepository : IRepository<OrderView>
    {
        Task<List<OrderView>> GetOrdersByDate(DateTime startDate, DateTime endDate);
    }
}
