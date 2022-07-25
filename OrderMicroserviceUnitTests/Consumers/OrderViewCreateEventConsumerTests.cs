using AutoFixture;
using AutoMapper;
using Common.MessageQueue.EventMessages;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using OrderMicroservice.Business.Commands.CreateCustomer;
using OrderMicroservice.Business.Commands.CreateOrderView;
using OrderMicroservice.Business.Mappers;
using OrderMicroservice.DataAccess.Entities;
using OrderMicroservice.DataAccess.Repositories;
using OrderMicroservice.MessageConsumer;
using System.Threading;
using Xunit;

namespace OrderMicroserviceUnitTests.Consumers
{
    public class OrderViewCreateEventConsumerTests
    {
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<ILogger<OrderViewCreateEventConsumer>> _logger;
        private readonly IMapper _mapper;

        public OrderViewCreateEventConsumerTests()
        {
            _mediator = new Mock<IMediator>();
            _logger = new Mock<ILogger<OrderViewCreateEventConsumer>>();
            _mapper = AutoMapperConfig.getMapper();
        }

        [Fact]
        public void Consume_Should_CallSendMethod()
        {
            //Arrange

            var fixture = new Fixture();

            fixture.Customize<OrderCreateEvent>(e => e.WithAutoProperties());

            var eventMessage = fixture.Build<OrderCreateEvent>()
                .Create();

            _mediator.Setup(x => x.Send(It.IsAny<CreateOrderViewCommand>(), It.IsAny<CancellationToken>()));

            OrderViewCreateEventConsumer consumer = new OrderViewCreateEventConsumer(_mediator.Object, _mapper, _logger.Object);

            var context = Mock.Of<ConsumeContext<OrderCreateEvent>>(_ =>_.Message == eventMessage);

            //Act
            consumer.Consume(context).GetAwaiter();

            //Assert
            _mediator.Verify(x => x.Send(It.IsAny<CreateOrderViewCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }

    }
}
