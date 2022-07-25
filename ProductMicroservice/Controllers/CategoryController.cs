using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Business.Dtos;
using ProductMicroservice.Business.Interfaces;

namespace ProductMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        [HttpPost]
        public ActionResult Create(CategoryDto categoryDto)
        {
            var categoryId = _categoryService.Create(categoryDto);
            return Ok($"Category created with id {categoryId}");
        }
    }
}
