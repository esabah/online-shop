using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderMicroservice.Business.Commands.CreateOrder;
using OrderMicroservice.Business.Queries.QueryOrders;
using OrderMicroservice.DataAccess.Entities;

namespace OrderMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderView>>> GetOrdersByDate(DateTime startDate, DateTime endDate)
        {
            var query = new GetOrdersQuery(startDate, endDate);
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }
    }
}
