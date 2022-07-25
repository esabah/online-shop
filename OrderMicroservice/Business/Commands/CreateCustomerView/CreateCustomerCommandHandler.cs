using AutoMapper;
using MediatR;
using OrderMicroservice.DataAccess.Entities;
using OrderMicroservice.DataAccess.Repositories;

namespace OrderMicroservice.Business.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        private readonly ICustomerViewRepository _customerViewRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCustomerCommandHandler> _logger;

        public CreateCustomerCommandHandler(ICustomerViewRepository customerViewRepository, IMapper mapper, ILogger<CreateCustomerCommandHandler> logger)
        {
            _customerViewRepository = customerViewRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
           
            var newOrder = _customerViewRepository.Create(request);
            await _customerViewRepository.CommitAsync();
            return newOrder.Id;
        }

    }
}
