using MediatR;
using Microsoft.AspNetCore.Mvc;
using WheelzyChallenge.Application.UseCases.Orders.Queries;
using WheelzyChallenge.Domain.ReadModels;

namespace WheelyChallenge.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderReadModel>>> GetOrders(
            [FromQuery] DateTime? dateFrom,
            [FromQuery] DateTime? dateTo,
            [FromQuery] List<int>? customerIds,
            [FromQuery] List<int>? statusIds,
            [FromQuery] bool? isActive)
        {
            var query = new GetOrdersQuery
            {
                DateFrom = dateFrom,
                DateTo = dateTo,
                CustomerIds = customerIds,
                StatusIds = statusIds,
                IsActive = isActive
            };

            var result = await _mediator.Send(query);

            if (result == null || !result.Any())
                return NotFound();

            return Ok(result);
        }
    }
}
