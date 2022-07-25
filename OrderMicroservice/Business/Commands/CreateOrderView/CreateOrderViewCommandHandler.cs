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

        public CreateOrderViewCommandHandler(IOrderViewRepository orderQueryRepository)
        {
            _orderQueryRepository = orderQueryRepository;
        }

        public async Task<int> Handle(CreateOrderViewCommand request, CancellationToken cancellationToken)
        {
            var newOrder = _orderQueryRepository.Create(request);
            await _orderQueryRepository.CommitAsync();
            return newOrder.Id;
        }
    }
}
