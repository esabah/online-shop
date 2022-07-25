using MediatR;
using OrderMicroservice.DataAccess.Entities;

namespace OrderMicroservice.Business.Commands.CreateProduct
{
    public class CreateProductCommand : ProductView , IRequest<int>
    {

    }
}
