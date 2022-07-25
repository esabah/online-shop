using AutoFixture;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using OrderMicroservice.Business.Commands.CreateCustomer;
using OrderMicroservice.Business.Commands.CreateOrderView;
using OrderMicroservice.Business.Commands.CreateORderView;
using OrderMicroservice.Business.Mappers;
using OrderMicroservice.DataAccess.Entities;
using OrderMicroservice.DataAccess.Repositories;
using Xunit;

namespace OrderMicroserviceUnitTests.Commands
{
    public class CreateOrderViewTests
    {
        private readonly Mock<IOrderViewRepository> _orderViewRepository;
        private readonly IMapper _mapper;


        public CreateOrderViewTests()
        {
            _orderViewRepository = new Mock<IOrderViewRepository>();
            _mapper = AutoMapperConfig.getMapper();
        }

        [Fact]
        public void Create_Should_ReturnId()
        {
            //Arrange

            var fixture = new Fixture();

            fixture.Customize<CreateCustomerCommand>(e => e.WithAutoProperties());

            var order = fixture.Build<CreateOrderViewCommand>()
                .Create();
            order.Id = 1;

            var resultOrder = _mapper.Map<CreateOrderViewCommand, OrderView>(order);

            _orderViewRepository.Setup(x => x.Create(It.IsAny<OrderView>())).Returns(resultOrder);



            CreateOrderViewCommandHandler handler = new CreateOrderViewCommandHandler(_orderViewRepository.Object);

            //Act
            var result = handler.Handle(order, new System.Threading.CancellationToken()).GetAwaiter().GetResult();

            //Assert
            Assert.Equal(1, result);
        }

    }
}
