using AutoFixture;
using AutoMapper;
using OrderMicroservice.Business.Dtos;
using OrderMicroservice.Business.Mappers;
using OrderMicroservice.DataAccess.Entities;
using OrderMicroservice.DataAccess.Repositories;
using MassTransit;
using Moq;
using System.Linq;
using Xunit;
using OrderMicroservice.Business.Commands.CreateOrder;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace OrderMicroserviceUnitTests.Commands
{
    public class CreateOrderTests
    {

        private readonly Mock<IOrderRepository> _orderRepository;
        private readonly Mock<ICustomerViewRepository> _customerViewRepository;
        private readonly Mock<IProductViewRepository> _productViewRepository;
        private readonly Mock<IPublishEndpoint> _publishEndpoint;
        private readonly Mock<ILogger<CreateOrderCommandHandler>> _logger;
        private readonly IMapper _mapper;


        public CreateOrderTests()
        {
            _orderRepository = new Mock<IOrderRepository>();
            _customerViewRepository = new Mock<ICustomerViewRepository>();
            _productViewRepository = new Mock<IProductViewRepository>();
            _publishEndpoint =new Mock<IPublishEndpoint>();
            _logger = new Mock<ILogger<CreateOrderCommandHandler>>();
            _mapper = AutoMapperConfig.getMapper();
        }

        [Fact]
        public void Create_Should_ReturnId()
        {
            //Arrange

            var fixture = new Fixture();

            fixture.Customize<CreateOrderCommand>(e => e.WithAutoProperties());
        
            var customer = fixture.Build<CustomerView>()
                .With(s=> s.Id,1)
                .Create();

            var product = fixture.Build<ProductView>()
                .With(s => s.Id, 1)
                .Create();

            var orderDetail = fixture.Build<OrderDetailDto>()
                .With(s => s.ProductId, 1)
                .Create();

            var orderCommand = fixture.Build<CreateOrderCommand>()
                .With(s => s.CustomerId, 1)
                .With(s => s.OrderDetails,new List<OrderDetailDto>{ orderDetail })
             .Create();

            var resultOrder = _mapper.Map<CreateOrderCommand, Order>(orderCommand);
            resultOrder.Id = 9;

            _customerViewRepository.Setup(x => x.GetById(1)).Returns(customer);
            _productViewRepository.Setup(x => x.GetById(1)).Returns(product);
            _productViewRepository.Setup(x => x.GetByIdList(It.IsAny<int[]>())).Returns(new List<ProductView>() { product });

            _orderRepository.Setup(x => x.Create(It.IsAny<Order>())).Returns(resultOrder);

            CreateOrderCommandHandler handler = new CreateOrderCommandHandler(_orderRepository.Object,_customerViewRepository.Object,_productViewRepository.Object,_mapper,_logger.Object,_publishEndpoint.Object);

            //Act
            var result = handler.Handle(orderCommand, new System.Threading.CancellationToken()).GetAwaiter().GetResult();

            //Assert
            Assert.Equal(9, result);    
        }
    }
}
