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

        public CategoryControllerTests()
        {
            _categoryService = new Mock<ICategoryService>();
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


            CategoryController controller = new CategoryController(_categoryService.Object);

            //Act
            var result = controller.Create(categoryDto);

            //Assert

            var okResult = result as ObjectResult;
            Assert.NotNull(okResult);

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            Assert.Equal(200, okResult.StatusCode);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
    }
}
