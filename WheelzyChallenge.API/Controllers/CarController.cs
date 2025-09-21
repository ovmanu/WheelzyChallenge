using MediatR;
using Microsoft.AspNetCore.Mvc;
using WheelzyChallenge.Application.UseCases.Cars.GetCarById.DTOs;
using WheelzyChallenge.Application.UseCases.Cars.GetCarById.Queries;
using WheelzyChallenge.Application.UseCases.Cars.GetCarsWithQuoteAndStatus.DTOs;
using WheelzyChallenge.Application.UseCases.Cars.GetCarsWithQuoteAndStatus.Queries;

namespace WheelzyChallenge.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarWithQuoteAndStatusDto>>> GetAll()
        {
            var result = await _mediator.Send(new GetCarsWithQuoteAndStatusQuery());
            return Ok(result);
        }
        

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetCarByIdQuery { CarId = id });
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
