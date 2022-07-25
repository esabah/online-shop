using AutoMapper;
using Common.MessageQueue.EventMessages;
using MassTransit;
using MediatR;
using OrderMicroservice.Business.Dtos;
using OrderMicroservice.DataAccess.Entities;
using OrderMicroservice.DataAccess.Repositories;
using System.Linq;

namespace OrderMicroservice.Business.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerViewRepository _customerViewRepository;
        private readonly IProductViewRepository _productViewRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateOrderCommandHandler> _logger;
        private readonly IPublishEndpoint _publishEndpoint;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, ICustomerViewRepository customerViewRepository, IProductViewRepository productViewRepository, IMapper mapper, ILogger<CreateOrderCommandHandler> logger, IPublishEndpoint publishEndpoint)
        {
            _orderRepository = orderRepository;
            _customerViewRepository = customerViewRepository;
            _productViewRepository = productViewRepository;
            _mapper = mapper;
            _logger = logger;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var orderEntity = _mapper.Map<CreateOrderCommand, Order>(request);

            if(request.OrderDetails != null)
               orderEntity.OrderDetails = _mapper.Map<ICollection<OrderDetailDto>, ICollection<OrderDetail>>(request.OrderDetails);

            var customerDetail = _customerViewRepository.GetById(orderEntity.CustomerId);
            validateConsistancy(customerDetail, orderEntity);

            orderEntity.Status = "Created";
            var newOrder =  _orderRepository.Create(orderEntity);
            await _orderRepository.CommitAsync();

            // Send created order info to rabbitMq for update query db.
             
           await _publishEndpoint.Publish<OrderCreateEvent>(BuildMessage(customerDetail , newOrder));

            return newOrder.Id;
        }

        private OrderCreateEvent BuildMessage(CustomerView customerDetail,Order order)
        {
            OrderCreateEvent orderCreateEvent = _mapper.Map<Order, OrderCreateEvent>(order);
            orderCreateEvent =_mapper.Map<CustomerView, OrderCreateEvent>(customerDetail, orderCreateEvent);

            if (orderCreateEvent.OrderDetails != null && order.OrderDetails != null)
            {
                var productsInOrder = _productViewRepository.GetByIdList(order.OrderDetails.Select(x => x.ProductId).ToArray());
                orderCreateEvent.OrderDetails.ToList().ForEach(x => x.ProductName = productsInOrder.FirstOrDefault(y => y.Id == x.ProductId)?.Name ?? "");
            }

            return orderCreateEvent;
        }

        private void validateConsistancy(CustomerView customerDetail, Order orderEntity)
        {
            if (customerDetail == null)
            {
                throw new ArgumentException($"Customer with id {orderEntity.CustomerId} not found)");
            }


            if (orderEntity.OrderDetails != null)
            {
                var productsInOrder = _productViewRepository.GetByIdList(orderEntity.OrderDetails.Select(x => x.ProductId).ToArray()).ToList();

                foreach (var item in orderEntity.OrderDetails.Select(x => x.ProductId))
                {
                    if (!productsInOrder.Any(x => x.Id == item))
                    {
                        throw new ArgumentException($"Product with id {item} not found)");
                    }
                }
            }
        }

        
    }
}
