using AutoFixture;
using AutoMapper;
using CustomerMicroservice.Business.Dtos;
using CustomerMicroservice.Business.Interfaces;
using CustomerMicroservice.Business.Mappers;
using CustomerMicroservice.Business.Services;
using CustomerMicroservice.Controllers;
using CustomerMicroservice.DataAccess.Entities;
using CustomerMicroservice.DataAccess.Repositories;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CustomerMicroserviceUnitTests.Services
{
    public class CustomerControllerTests
    {

   
        private readonly Mock<ICustomerService> _customerService;
        private readonly Mock<ILogger<CustomerController>> _logger;

        public CustomerControllerTests()
        {
            _customerService = new Mock<ICustomerService>();
            _logger = new Mock<ILogger<CustomerController>>();
        }

        [Fact]
        public void Create_Should_ReturnOk()
        {
            //Arrange

            var customerFixture = new Fixture();

            customerFixture.Customize<CustomerDto>(e => e.WithAutoProperties());

            var customerDto = customerFixture.Build<CustomerDto>()
                .Without(s => s.Id)
                .Create();

            _customerService.Setup(x => x.Create(customerDto)).Returns(1);


            CustomerController controller = new CustomerController(_customerService.Object,_logger.Object);

            //Act
            var result = controller.Create(customerDto);

            //Assert

            var okResult = result as ObjectResult;
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public void Get_Should_ReturnCorrrectNumberOfElements()
        {
            //Arrange

            var customerFixture = new Fixture();

            customerFixture.Customize<CustomerDto>(e => e.WithAutoProperties());
            var customerList = customerFixture.Build<CustomerDto>()
                .CreateMany(5);

            _customerService.Setup(x => x.GetAll()).Returns(customerList);

            CustomerController controller = new CustomerController(_customerService.Object, _logger.Object);

            //Act

            var result = controller.GetAll();

            //Assert
            var res = result.Result as ObjectResult;

            Assert.Equal(200,res.StatusCode);
        }
    }
}
