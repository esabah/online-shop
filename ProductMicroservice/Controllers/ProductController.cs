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
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
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
