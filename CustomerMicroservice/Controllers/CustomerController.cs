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

        public CustomerController(ICustomerService customerService)
        {
            this._customerService = customerService;
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
