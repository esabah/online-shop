using AutoFixture;
using AutoMapper;
using Common.MessageQueue.EventMessages;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using OrderMicroservice.Business.Commands.CreateCustomer;
using OrderMicroservice.Business.Commands.CreateProduct;
using OrderMicroservice.Business.Mappers;
using OrderMicroservice.DataAccess.Entities;
using OrderMicroservice.DataAccess.Repositories;
using OrderMicroservice.MessageConsumer;
using System.Threading;
using Xunit;

namespace OrderMicroserviceUnitTests.Consumers
{
    public class ProductCreateEventConsumerTests
    {
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<ILogger<ProductCreateEventConsumer>> _logger;
        private readonly IMapper _mapper;

        public ProductCreateEventConsumerTests()
        {
            _mediator = new Mock<IMediator>();
            _logger = new Mock<ILogger<ProductCreateEventConsumer>>();
            _mapper = AutoMapperConfig.getMapper();
        }

        [Fact]
        public void Consume_Should_CallSendMethod()
        {
            //Arrange

            var fixture = new Fixture();

            fixture.Customize<ProductCreateEvent>(e => e.WithAutoProperties());

            var eventMessage = fixture.Build<ProductCreateEvent>()
                .Create();

            _mediator.Setup(x => x.Send(It.IsAny<CreateProductCommand>(), It.IsAny<CancellationToken>()));

            ProductCreateEventConsumer consumer = new ProductCreateEventConsumer(_mediator.Object, _mapper, _logger.Object);

            var context = Mock.Of<ConsumeContext<ProductCreateEvent>>(_ =>_.Message == eventMessage);

            //Act
            consumer.Consume(context).GetAwaiter();

            //Assert
            _mediator.Verify(x => x.Send(It.IsAny<CreateProductCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }

    }
}
