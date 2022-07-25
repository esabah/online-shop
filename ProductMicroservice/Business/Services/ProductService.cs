using AutoMapper;
using Common.MessageQueue.EventMessages;
using MassTransit;
using ProductMicroservice.Business.Dtos;
using ProductMicroservice.Business.Interfaces;
using ProductMicroservice.DataAccess.Entities;
using ProductMicroservice.DataAccess.Repositories;

namespace ProductMicroservice.Business.Services
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public ProductService(IProductRepository productRepository, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        public int Create(ProductDto productDto)
        {
            var productToCreate = _mapper.Map<ProductDto, Product>(productDto);
            var product = _productRepository.Create(productToCreate);
            _productRepository.Commit();

            // Send created customer info to rabbit for order query.

            var eventMessage = _mapper.Map<Product, ProductCreateEvent>(productToCreate);
            _publishEndpoint.Publish<ProductCreateEvent>(eventMessage);

            return product.Id;
        }

        public IEnumerable<ProductDto> GetAll()
        {
            var products = _productRepository.GetAll();
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products);
        }
    }
}
