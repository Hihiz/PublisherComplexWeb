using MediatR;
using Microsoft.AspNetCore.Mvc;
using PublisherComplexWeb.CQRS.Application.Orders.Commands.CreateOrder;
using PublisherComplexWeb.CQRS.Application.Orders.Commands.DeleteOrder;
using PublisherComplexWeb.CQRS.Application.Orders.Commands.UpdateOrder;
using PublisherComplexWeb.CQRS.Application.Orders.Queries.GetCloseOrderList;
using PublisherComplexWeb.CQRS.Application.Orders.Queries.GetOpenOrderList;
using PublisherComplexWeb.CQRS.Application.Orders.Queries.GetOrderDetail;
using PublisherComplexWeb.CQRS.Application.Orders.Queries.GetOrderList;

namespace PublisherComplexWeb.CQRS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult> GetOrders()
        {
            GetOrderListQuery query = new GetOrderListQuery();
            
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("orderOpen")]
        public async Task<ActionResult> GetOrderOpen()
        {
            GetOpenOrderListQuery query = new GetOpenOrderListQuery();
            
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("orderClose")]
        public async Task<ActionResult> GetOrderClose()
        {
            GetCloseOrderListQuery query = new GetCloseOrderListQuery();
            
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetOrder(int id)
        {
            GetOrderDetailQuery query = new GetOrderDetailQuery(id);
            
            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder(CreateOrderCommand command) => Ok(await _mediator.Send(command));

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrder(int id, UpdateOrderCommand command)
        {
            if (id != command.Id)
            {
                return NotFound();
            }

            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            DeleteOrderCommand command = new DeleteOrderCommand(id);

            return Ok(await _mediator.Send(command));
        }
    }
}
