using AutoFixture;
using AutoMapper;
using Common.MessageQueue.EventMessages;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using OrderMicroservice.Business.Commands.CreateCustomer;
using OrderMicroservice.Business.Mappers;
using OrderMicroservice.DataAccess.Entities;
using OrderMicroservice.DataAccess.Repositories;
using OrderMicroservice.MessageConsumer;
using System.Threading;
using Xunit;

namespace OrderMicroserviceUnitTests.Consumers
{
    public class CustomerCreateEventConsumerTests
    {
        private readonly Mock<IMediator> _mediator;
        private readonly IMapper _mapper;

        public CustomerCreateEventConsumerTests()
        {
            _mediator = new Mock<IMediator>();
            _mapper = AutoMapperConfig.getMapper();
        }

        [Fact]
        public void Consume_Should_CallSendMethod()
        {
            //Arrange

            var fixture = new Fixture();

            fixture.Customize<CustomerCreateEvent>(e => e.WithAutoProperties());

            var eventMessage = fixture.Build<CustomerCreateEvent>()
                .Create();

            _mediator.Setup(x => x.Send(It.IsAny<CreateCustomerCommand>(), It.IsAny<CancellationToken>()));

            CustomerCreateEventConsumer consumer = new CustomerCreateEventConsumer(_mediator.Object, _mapper);

            var context = Mock.Of<ConsumeContext<CustomerCreateEvent>>(_ =>_.Message == eventMessage);

            //Act
            consumer.Consume(context).GetAwaiter();

            //Assert
            _mediator.Verify(x => x.Send(It.IsAny<CreateCustomerCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }

    }
}
