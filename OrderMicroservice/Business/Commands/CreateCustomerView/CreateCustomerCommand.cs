using MediatR;
using OrderMicroservice.DataAccess.Entities;

namespace OrderMicroservice.Business.Commands.CreateCustomer
{
    public class CreateCustomerCommand : CustomerView, IRequest<int>
    {
       

    }
}
