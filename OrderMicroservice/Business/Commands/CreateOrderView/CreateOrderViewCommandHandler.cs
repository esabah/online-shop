using AutoMapper;
using MediatR;
using OrderMicroservice.Business.Commands.CreateOrderView;
using OrderMicroservice.DataAccess.Entities;
using OrderMicroservice.DataAccess.Repositories;

namespace OrderMicroservice.Business.Commands.CreateORderView
{
    public class CreateOrderViewCommandHandler  :  IRequestHandler<CreateOrderViewCommand, int>
    {
        private readonly IOrderViewRepository _orderQueryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateOrderViewCommandHandler> _logger;

        public CreateOrderViewCommandHandler(IOrderViewRepository orderQueryRepository, IMapper mapper, ILogger<CreateOrderViewCommandHandler> logger)
        {
            _orderQueryRepository = orderQueryRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateOrderViewCommand request, CancellationToken cancellationToken)
        {
            var newOrder = _orderQueryRepository.Create(request);
            await _orderQueryRepository.CommitAsync();
            return newOrder.Id;
        }
    }
}
