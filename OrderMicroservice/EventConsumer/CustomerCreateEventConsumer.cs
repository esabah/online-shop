using AutoMapper;
using Common.MessageQueue.EventMessages;
using MassTransit;
using MediatR;
using OrderMicroservice.Business.Commands.CreateCustomer;
using OrderMicroservice.DataAccess.Entities;

namespace OrderMicroservice.MessageConsumer
{
    public class CustomerCreateEventConsumer : IConsumer<CustomerCreateEvent>
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CustomerCreateEventConsumer(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<CustomerCreateEvent> context)
        {
            var command = _mapper.Map<CreateCustomerCommand>(context.Message);
            await _mediator.Send(command);
        }
    }
}
