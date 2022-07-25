using Common.Repository;
using Microsoft.EntityFrameworkCore;
using OrderMicroservice.DataAccess.Entities;

namespace OrderMicroservice.DataAccess.Repositories
{
    public class OrderViewRepository : RepositoryBase<OrderView>, IOrderViewRepository
    {
        protected readonly ViewContext _orderQueryContext;

        public OrderViewRepository(ViewContext orderQueryContext) : base(orderQueryContext)
        {
            _orderQueryContext = orderQueryContext;
        }

        public async Task<List<OrderView>> GetOrdersByDate(DateTime startDate, DateTime endDate)
        {
            return await _orderQueryContext.OrderViews.Where(x=> x.OrderDate>= startDate && x.OrderDate<= endDate).Include(y=> y.OrderDetails).ToListAsync(); 
        }
    }
}
