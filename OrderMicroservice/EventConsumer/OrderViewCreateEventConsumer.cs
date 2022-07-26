﻿using AutoMapper;
using Common.MessageQueue.EventMessages;
using MassTransit;
using MediatR;
using OrderMicroservice.Business.Commands.CreateCustomer;
using OrderMicroservice.Business.Commands.CreateOrderView;
using OrderMicroservice.DataAccess.Entities;

namespace OrderMicroservice.MessageConsumer
{
    public class OrderViewCreateEventConsumer : IConsumer<OrderCreateEvent>
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrderViewCreateEventConsumer(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<OrderCreateEvent> context)
        {
            var command = _mapper.Map<CreateOrderViewCommand>(context.Message);
            await _mediator.Send(command);
        }
    }
}
