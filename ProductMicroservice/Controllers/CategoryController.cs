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

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public ActionResult Create(CategoryDto categoryDto)
        {
            var categoryId = _categoryService.Create(categoryDto);
            return Ok($"Category created with id {categoryId}");
        }
    }
}
