using AutoMapper;
using MediatR;
using OrderMicroservice.DataAccess.Entities;
using OrderMicroservice.DataAccess.Repositories;

namespace OrderMicroservice.Business.Commands.CreateProduct
{
    public class CreateProductCommandHandler  :  IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductViewRepository _productViewRepository;

        public CreateProductCommandHandler(IProductViewRepository productViewRepository)
        {
            _productViewRepository = productViewRepository;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var newOrder = _productViewRepository.Create(request);
            await _productViewRepository.CommitAsync();
            return newOrder.Id;
        }
    }
}
