using AutoMapper;
using Common.MessageQueue.EventMessages;
using ProductMicroservice.Business.Dtos;
using ProductMicroservice.Business.Interfaces;
using ProductMicroservice.DataAccess.Entities;
using ProductMicroservice.DataAccess.Repositories;

namespace ProductMicroservice.Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public int Create(CategoryDto categoryDto)
        {
            var categoryToCreate = _mapper.Map<CategoryDto, Category>(categoryDto);
            var category = _categoryRepository.Create(categoryToCreate);
            _categoryRepository.Commit();

            return category.Id;
        }

    }
}
