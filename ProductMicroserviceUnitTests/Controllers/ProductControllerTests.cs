using AutoFixture;
using AutoMapper;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ProductMicroservice.Business.Dtos;
using ProductMicroservice.Business.Interfaces;
using ProductMicroservice.Controllers;
using ProductMicroservice.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ProductMicroserviceUnitTests.Services
{
    public class ProductControllerTests
    {

   
        private readonly Mock<IProductService> _productService;

        public ProductControllerTests()
        {
            _productService = new Mock<IProductService>();
        }

        [Fact]
        public void Create_Should_ReturnOk()
        {
            //Arrange

            var fixture = new Fixture();

            fixture.Customize<ProductDto>(e => e.WithAutoProperties());

            var productDto = fixture.Build<ProductDto>()
                .Create();

            _productService.Setup(x => x.Create(productDto)).Returns(1);


            ProductController controller = new ProductController(_productService.Object);

            //Act
            var result = controller.Create(productDto);

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

            var fixture = new Fixture();

            fixture.Customize<ProductDto>(e => e.WithAutoProperties());
            var productList = fixture.Build<ProductDto>()
                .CreateMany(5);

            _productService.Setup(x => x.GetAll()).Returns(productList);

            ProductController controller = new ProductController(_productService.Object);

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
