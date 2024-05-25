using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Query.Orders.GetById;

namespace Shop.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private IMediator _mediator;

        public WeatherForecastController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Route("/test")]
        public async Task<IActionResult> GetOrders()
        {
            var result = await _mediator.Send(new GetOrderByIdQuery(2));
            return Ok(result);
        }
    }
}
