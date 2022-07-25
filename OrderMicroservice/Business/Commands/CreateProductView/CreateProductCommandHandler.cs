using AutoMapper;
using MediatR;
using OrderMicroservice.DataAccess.Entities;
using OrderMicroservice.DataAccess.Repositories;

namespace OrderMicroservice.Business.Commands.CreateProduct
{
    public class CreateProductCommandHandler  :  IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductViewRepository _productViewRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateProductCommandHandler> _logger;

        public CreateProductCommandHandler(IProductViewRepository productViewRepository, IMapper mapper, ILogger<CreateProductCommandHandler> logger)
        {
            _productViewRepository = productViewRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var newOrder = _productViewRepository.Create(request);
            await _productViewRepository.CommitAsync();
            return newOrder.Id;
        }
    }
}
