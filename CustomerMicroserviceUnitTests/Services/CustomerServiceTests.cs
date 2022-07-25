using AutoFixture;
using AutoMapper;
using CustomerMicroservice.Business.Dtos;
using CustomerMicroservice.Business.Mappers;
using CustomerMicroservice.Business.Services;
using CustomerMicroservice.DataAccess.Entities;
using CustomerMicroservice.DataAccess.Repositories;
using MassTransit;
using Moq;
using System.Linq;
using Xunit;

namespace CustomerMicroserviceUnitTests.Services
{
    public class CustomerServiceTests
    {

        private readonly Mock<ICustomerRepository> _customerRepository;
        private readonly Mock<IPublishEndpoint> _publishEndpoint;
        private readonly IMapper _mapper;

        public CustomerServiceTests()
        {
            _customerRepository = new Mock<ICustomerRepository>();
            _publishEndpoint = new Mock<IPublishEndpoint>();


            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfiles());
            });
            _mapper = mappingConfig.CreateMapper();

        }

        [Fact]
        public void Create_Should_ReturnId()
        {
            //Arrange

            var customerFixture = new Fixture();

            customerFixture.Customize<Customer>(e => e.WithAutoProperties());
            var customer= customerFixture.Build<Customer>()
                .With(s => s.Id,1)
                .Create();

            var customerDto = customerFixture.Build<CustomerDto>()
                .Without(s => s.Id)
                .Create();


            _customerRepository.Setup(x => x.Create(It.IsAny<Customer>())).Returns(customer);

            CustomerService service = new CustomerService(_customerRepository.Object, _mapper, _publishEndpoint.Object);

            //Act
            var sut = service.Create(customerDto);

            //Assert
            Assert.Equal(1,sut);    
        }

        [Fact]
        public void Get_Should_ReturnCorrectNumberOfElements()
        {
            //Arrange

            var customerFixture = new Fixture();

            customerFixture.Customize<CustomerDto>(e => e.WithAutoProperties());
            var customerList = customerFixture.Build<Customer>()
                .CreateMany(5);

            _customerRepository.Setup(x => x.GetAll()).Returns(customerList);

            CustomerService service = new CustomerService(_customerRepository.Object, _mapper, _publishEndpoint.Object);

            //Act

            var sut = service.GetAll();

            //Assert

            Assert.Equal(customerList.Count(), sut.Count());
        }
    }
}
