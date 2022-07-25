using AutoFixture;
using AutoMapper;
using Moq;
using ProductMicroservice.Business.Dtos;
using ProductMicroservice.Business.Mappers;
using ProductMicroservice.Business.Services;
using ProductMicroservice.DataAccess.Entities;
using ProductMicroservice.DataAccess.Repositories;
using Xunit;

namespace ProductMicroserviceUnitTests.Services
{
    public class CategoryServiceTests
    {

        private readonly Mock<ICategoryRepository> _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryServiceTests()
        {
            _categoryRepository = new Mock<ICategoryRepository>();

            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new AutoMapperProfiles()); });
            IMapper mapper = mappingConfig.CreateMapper();
            _mapper = mapper;

        }

        [Fact]
        public void Create_Should_ReturnId()
        {
            //Arrange

            var fixture = new Fixture();

            fixture.Customize<Category>(e => e.WithAutoProperties());
            var category = fixture.Build<Category>()
                .With(s => s.Id, 1)
                .Create();

            var categoryDto = fixture.Build<CategoryDto>()
                .Create();


            _categoryRepository.Setup(x => x.Create(It.IsAny<Category>())).Returns(category);

            CategoryService service = new CategoryService(_categoryRepository.Object, _mapper);

            //Act
            var sut = service.Create(categoryDto);

            //Assert
            Assert.Equal(1, sut);
        }
    }
}
