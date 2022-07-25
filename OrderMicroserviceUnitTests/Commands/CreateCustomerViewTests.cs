using AutoFixture;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using OrderMicroservice.Business.Commands.CreateCustomer;
using OrderMicroservice.Business.Mappers;
using OrderMicroservice.DataAccess.Entities;
using OrderMicroservice.DataAccess.Repositories;
using Xunit;

namespace OrderMicroserviceUnitTests.Commands
{
    public class CreateCustomerViewTests
    {
        private readonly Mock<ICustomerViewRepository> _customerViewRepository;
        private readonly IMapper _mapper;


        public CreateCustomerViewTests()
        {
            _customerViewRepository = new Mock<ICustomerViewRepository>();
            _mapper = AutoMapperConfig.getMapper();
        }

        [Fact]
        public void Create_Should_ReturnId()
        {
            //Arrange

            var fixture = new Fixture();

            fixture.Customize<CreateCustomerCommand>(e => e.WithAutoProperties());

            var customer = fixture.Build<CreateCustomerCommand>()
                .With(s => s.Id, 1)
                .Create();


            var resultCustomer = _mapper.Map<CreateCustomerCommand, CustomerView>(customer);

            _customerViewRepository.Setup(x => x.Create(It.IsAny<CustomerView>())).Returns(resultCustomer);



            CreateCustomerCommandHandler handler = new CreateCustomerCommandHandler(_customerViewRepository.Object, _mapper);

            //Act
            var result = handler.Handle(customer, new System.Threading.CancellationToken()).GetAwaiter().GetResult();

            //Assert
            Assert.Equal(1, result);
        }

    }
}
