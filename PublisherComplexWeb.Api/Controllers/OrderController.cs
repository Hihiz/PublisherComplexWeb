using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublisherComplexWeb.Application.Dto.Order;
using PublisherComplexWeb.Application.Interfaces;
using PublisherComplexWeb.Application.Validations.FluentValidations.Order;

using ValidationResult = FluentValidation.Results.ValidationResult;

namespace PublisherComplexWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService) => _orderService = orderService;

        [HttpGet]
        public async Task<ActionResult> GetOrders() => Ok(await _orderService.GetAll());

        [HttpGet("orderOpen")]
        public async Task<ActionResult> GetOrdersOpenStatus() => Ok(await _orderService.GetOrdersOpen());

        [HttpGet("orderClose")]
        public async Task<ActionResult> GetOrdersCloseStatus() => Ok(await _orderService.GetOrdersClose());

        [HttpGet("{id}")]
        public async Task<ActionResult> GetOrder(int id) => Ok(await _orderService.GetById(id));

        //[Authorize(Roles = "Member, Admin")]
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CreateOrder(CreateOrderDto dto)
        {
            CreateOrderValidator validators = new CreateOrderValidator();

            ValidationResult result = validators.Validate(dto);

            if (!result.IsValid)
            {
                return BadRequest(string.Join('\n', result.Errors));
            }

            return Ok(await _orderService.CreateOrder(dto));
        }

        //[Authorize(Roles = "Member, Admin")]
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrder(int id, UpdateOrderDto dto)
        {
            UpdateOrderValidator validators = new UpdateOrderValidator();

            ValidationResult result = validators.Validate(dto);

            if (!result.IsValid)
            {
                return BadRequest(string.Join('\n', result.Errors));
            }

            return Ok(await _orderService.UpdateOrder(id, dto));
        }

        //[Authorize(Roles = "Admin")]
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(int id) => Ok(await _orderService.DeleteOrder(id));
    }
}
