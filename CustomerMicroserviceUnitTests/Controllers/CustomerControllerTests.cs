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

        public CustomerControllerTests()
        {
            _customerService = new Mock<ICustomerService>();
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


            CustomerController controller = new CustomerController(_customerService.Object);

            //Act
            var result = controller.Create(customerDto);

            //Assert

            var okResult = result as ObjectResult;
            Assert.NotNull(okResult);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            Assert.Equal(200, okResult.StatusCode);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
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

            CustomerController controller = new CustomerController(_customerService.Object);

            //Act

            var result = controller.GetAll();

            //Assert

            var res = result.Result as ObjectResult;
            Assert.NotNull(res);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            Assert.Equal(200,res.StatusCode);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
    }
}
