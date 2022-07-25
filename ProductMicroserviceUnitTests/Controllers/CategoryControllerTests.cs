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
    public class CategoryControllerTests
    {

   
        private readonly Mock<ICategoryService> _categoryService;
        private readonly Mock<ILogger<CategoryController>> _logger;

        public CategoryControllerTests()
        {
            _categoryService = new Mock<ICategoryService>();
            _logger = new Mock<ILogger<CategoryController>>();
        }

        [Fact]
        public void Create_Should_ReturnOk()
        {
            //Arrange

            var fixture = new Fixture();

            fixture.Customize<CategoryDto>(e => e.WithAutoProperties());

            var categoryDto = fixture.Build<CategoryDto>()
                .Create();

            _categoryService.Setup(x => x.Create(categoryDto)).Returns(1);


            CategoryController controller = new CategoryController(_categoryService.Object,_logger.Object);

            //Act
            var result = controller.Create(categoryDto);

            //Assert

            var okResult = result as ObjectResult;
            Assert.Equal(200, okResult.StatusCode);
        }
    }
}
