using CustomerMicroservice.Business.Dtos;
using CustomerMicroservice.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<CustomerController> _logger;


        public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger)
        {
            this._customerService = customerService;
            this._logger = logger;
        }

        [HttpPost]
        public ActionResult Create(CustomerDto customerDto)
        {
            var customerId = _customerService.Create(customerDto);
            return Ok($"Customer created with id {customerId}");
        }

        [HttpGet]
        public ActionResult<List<CustomerDto>> GetAll()
        {
            return Ok(_customerService.GetAll());
        }
    }
}
