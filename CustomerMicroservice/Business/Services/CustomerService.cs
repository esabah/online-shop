using AutoMapper;
using Common.MessageQueue.EventMessages;
using CustomerMicroservice.Business.Dtos;
using CustomerMicroservice.Business.Interfaces;
using CustomerMicroservice.DataAccess.Entities;
using CustomerMicroservice.DataAccess.Repositories;
using MassTransit;

namespace CustomerMicroservice.Business.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        public int Create(CustomerDto customerDto)
        {
            var customerToCreate = _mapper.Map<CustomerDto, Customer>(customerDto);
            var customer = _customerRepository.Create(customerToCreate);
            _customerRepository.Commit();

            // Send created customer info to rabbit for order query.
            var eventMessage = _mapper.Map<Customer,CustomerCreateEvent>(customerToCreate);
            _publishEndpoint.Publish<CustomerCreateEvent>(eventMessage);

            return customer.Id;
        }

        public IEnumerable<CustomerDto> GetAll()
        {
            var customers = _customerRepository.GetAll();
            return _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDto>>(customers);
        }
    }
}
