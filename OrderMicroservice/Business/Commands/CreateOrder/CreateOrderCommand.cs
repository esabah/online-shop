using MediatR;
using OrderMicroservice.Business.Dtos;

namespace OrderMicroservice.Business.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<int>
    {
        public int CustomerId { get; set; }
        public string? BillingAddress { get; set; }
        public string? ShippingAddress { get; set; }
        public ICollection<OrderDetailDto>? OrderDetails { get; set; }
    }
}
