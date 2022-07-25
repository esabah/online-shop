using MediatR;
using OrderMicroservice.DataAccess.Entities;

namespace OrderMicroservice.Business.Queries.QueryOrders
{
    public class GetOrdersQuery:  IRequest<List<OrderView>>
    {
        public GetOrdersQuery(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
