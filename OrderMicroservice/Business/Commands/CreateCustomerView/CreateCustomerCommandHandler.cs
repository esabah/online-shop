using AutoMapper;
using MediatR;
using OrderMicroservice.DataAccess.Entities;
using OrderMicroservice.DataAccess.Repositories;

namespace OrderMicroservice.Business.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        private readonly ICustomerViewRepository _customerViewRepository;

        public CreateCustomerCommandHandler(ICustomerViewRepository customerViewRepository, IMapper mapper)
        {
            _customerViewRepository = customerViewRepository;
        }

        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
           
            var newOrder = _customerViewRepository.Create(request);
            await _customerViewRepository.CommitAsync();
            return newOrder.Id;
        }

    }
}
