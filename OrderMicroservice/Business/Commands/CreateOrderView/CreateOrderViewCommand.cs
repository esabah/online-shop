using MediatR;
using OrderMicroservice.DataAccess.Entities;

namespace OrderMicroservice.Business.Commands.CreateOrderView
{
    public class CreateOrderViewCommand : OrderView , IRequest<int>
    {

    }
}
