using AutoMapper;
using Common.MessageQueue.EventMessages;
using MassTransit;
using MediatR;
using OrderMicroservice.Business.Commands.CreateCustomer;
using OrderMicroservice.Business.Commands.CreateProduct;
using OrderMicroservice.DataAccess.Entities;

namespace OrderMicroservice.MessageConsumer
{
    public class ProductCreateEventConsumer : IConsumer<ProductCreateEvent>
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductCreateEventConsumer> _logger;

        public ProductCreateEventConsumer(IMediator mediator, IMapper mapper, ILogger<ProductCreateEventConsumer> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<ProductCreateEvent> context)
        {
            var command = _mapper.Map<CreateProductCommand>(context.Message);
            await _mediator.Send(command);
        }
    }
}
