using AutoMapper;
using MediatR;
using OrderMicroservice.DataAccess.Entities;
using OrderMicroservice.DataAccess.Repositories;

namespace OrderMicroservice.Business.Queries.QueryOrders
{
    public class GetOrdersHandler : IRequestHandler<GetOrdersQuery, List<OrderView>>
    {
        private readonly IOrderViewRepository _orderQueryRepository;

        public GetOrdersHandler(IOrderViewRepository orderQueryRepository)
        {
            _orderQueryRepository = orderQueryRepository;
        }

        public async Task<List<OrderView>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var orderList = await _orderQueryRepository.GetOrdersByDate(request.StartDate,request.EndDate);
            return orderList;
        }
    }
}
