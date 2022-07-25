using AutoFixture;
using AutoMapper;
using ProductMicroservice.Business.Dtos;
using ProductMicroservice.Business.Mappers;
using ProductMicroservice.Business.Services;
using ProductMicroservice.DataAccess.Entities;
using ProductMicroservice.DataAccess.Repositories;
using MassTransit;
using Moq;
using System.Linq;
using Xunit;

namespace ProductMicroserviceUnitTests.Services
{
    public class ProductServiceTests
    {

        private readonly Mock<IProductRepository> _productRepository;
        private readonly Mock<IPublishEndpoint> _publishEndpoint;

        private readonly IMapper _mapper;

        public ProductServiceTests()
        {
            _productRepository = new Mock<IProductRepository>();
            _publishEndpoint =new Mock<IPublishEndpoint>();

             
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AutoMapperProfiles());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            
        }

        [Fact]
        public void Create_Should_ReturnId()
        {
            //Arrange

            var fixture = new Fixture();

            fixture.Customize<Product>(e => e.WithAutoProperties());
            var product= fixture.Build<Product>()
                .With(s => s.Id,1)
                .Create();

            var productDto = fixture.Build<ProductDto>()
                .Create();


            _productRepository.Setup(x => x.Create(It.IsAny<Product>())).Returns(product);

            ProductService service = new ProductService(_productRepository.Object, _mapper, _publishEndpoint.Object);

            //Act
            var sut = service.Create(productDto);

            //Assert
            Assert.Equal(1,sut);    
        }

        [Fact]
        public void Get_Should_ReturnCorrrectNumberOfElements()
        {
            //Arrange

            var fixture = new Fixture();

            fixture.Customize<Product>(e => e.WithAutoProperties());
            var productList = fixture.Build<Product>()
                .CreateMany(5);

            _productRepository.Setup(x => x.GetAll()).Returns(productList);

            ProductService service = new ProductService(_productRepository.Object, _mapper, _publishEndpoint.Object);

            //Act

            var sut = service.GetAll();

            //Assert

            Assert.Equal(productList.ToList().Count, sut.Count());
        }
    }
}
