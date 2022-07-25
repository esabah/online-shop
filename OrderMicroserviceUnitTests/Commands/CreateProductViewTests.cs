using AutoFixture;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using OrderMicroservice.Business.Commands.CreateProduct;
using OrderMicroservice.Business.Mappers;
using OrderMicroservice.DataAccess.Entities;
using OrderMicroservice.DataAccess.Repositories;
using Xunit;

namespace OrderMicroserviceUnitTests.Commands
{
    public class CreateProductViewTests
    {
        private readonly Mock<IProductViewRepository> _productViewRepository;
        private readonly Mock<ILogger<CreateProductCommandHandler>> _logger;
        private readonly IMapper _mapper;


        public CreateProductViewTests()
        {
            _productViewRepository = new Mock<IProductViewRepository>();
            _logger = new Mock<ILogger<CreateProductCommandHandler>>();
            _mapper = AutoMapperConfig.getMapper();
        }

        [Fact]
        public void Create_Should_ReturnId()
        {
            //Arrange

            var fixture = new Fixture();

            fixture.Customize<CreateProductCommand>(e => e.WithAutoProperties());

            var product = fixture.Build<CreateProductCommand>()
                .With(s => s.Id, 1)
                .Create();


            var resultProduct = _mapper.Map<CreateProductCommand, ProductView>(product);

            _productViewRepository.Setup(x => x.Create(It.IsAny<ProductView>())).Returns(resultProduct);



            CreateProductCommandHandler handler = new CreateProductCommandHandler(_productViewRepository.Object, _mapper, _logger.Object);

            //Act
            var result = handler.Handle(product, new System.Threading.CancellationToken()).GetAwaiter().GetResult();

            //Assert
            Assert.Equal(1, result);
        }
    }
}
