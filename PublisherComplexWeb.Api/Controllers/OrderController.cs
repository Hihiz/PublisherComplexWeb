using Microsoft.AspNetCore.Mvc;

namespace PublisherComplexWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService) => orderService = _orderService;

        [HttpGet]
        public async Task<ActionResult> GetOrders() => Ok(await _orderService.GetAll());
    }
}
