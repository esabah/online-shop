using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Business.Dtos;
using ProductMicroservice.Business.Interfaces;

namespace ProductMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public ActionResult Create(ProductDto productDto)
        {
            var productId = _productService.Create(productDto);
            return Ok($"Product created with id {productId}");
        }

        [HttpGet]
        public ActionResult<List<ProductDto>> GetAll()
        {
            return Ok(_productService.GetAll());
        }
    }
}
