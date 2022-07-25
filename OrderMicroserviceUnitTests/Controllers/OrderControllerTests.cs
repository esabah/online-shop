using AutoFixture;
using MediatR;
using Moq;
using OrderMicroservice.Business.Commands.CreateOrder;
using OrderMicroservice.Business.Queries.QueryOrders;
using OrderMicroservice.Controllers;
using System;
using System.Threading;
using Xunit;

namespace OrderMicroserviceUnitTests.Controllers
{
    public class OrderControllerTests
    {
        private readonly Mock<IMediator> _mediator;

        public OrderControllerTests()
        {
            _mediator = new Mock<IMediator>();
        }

        [Fact]
        public void CreateOrder_Should_SendCommand()
        {
            //Arrange

            var fixture = new Fixture();

            fixture.Customize<CreateOrderCommand>(e => e.WithAutoProperties());

            var orderCommand = fixture.Build<CreateOrderCommand>()
                .Create();

            _mediator.Setup(x => x.Send(It.IsAny<CreateOrderCommand>(), It.IsAny<CancellationToken>()));

            OrderController controller = new OrderController(_mediator.Object);


            //Act
            controller.Create(orderCommand).GetAwaiter();

            //Assert
            _mediator.Verify(x => x.Send(It.IsAny<CreateOrderCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public void Consume_Should_SendQuery()
        {
            //Arrange
            _mediator.Setup(x => x.Send(It.IsAny<GetOrdersQuery>(), It.IsAny<CancellationToken>()));
            OrderController controller = new OrderController(_mediator.Object);

            //Act
            controller.GetOrdersByDate(new DateTime(2022, 7, 1), new DateTime(2022, 7, 5)).GetAwaiter();

            //Assert
            _mediator.Verify(x => x.Send(It.IsAny<GetOrdersQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
