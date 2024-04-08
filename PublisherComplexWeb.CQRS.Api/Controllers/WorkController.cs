using MediatR;
using Microsoft.AspNetCore.Mvc;
using PublisherComplexWeb.CQRS.Application.Works.Commands.CreateWork;
using PublisherComplexWeb.CQRS.Application.Works.Commands.DeleteWork;
using PublisherComplexWeb.CQRS.Application.Works.Commands.UpdateWork;
using PublisherComplexWeb.CQRS.Application.Works.Queries.GetWorkDetail;
using PublisherComplexWeb.CQRS.Application.Works.Queries.GetWorkList;
using PublisherComplexWeb.CQRS.Application.Works.Queries.GetWorksOrderList;

namespace PublisherComplexWeb.CQRS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult> GetWorks()
        {
            GetWorkListQuery query = new GetWorkListQuery();

            return Ok(await _mediator.Send(query));
        }

        [HttpGet("worksOrder/{orderId}")]
        public async Task<ActionResult> GetWorksOrder(int orderId)
        {
            GetWorksOrderListQuery query = new GetWorksOrderListQuery(orderId);

            return Ok(await _mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetWork(int id)
        {
            GetWorkDetailQuery query = new GetWorkDetailQuery(id);

            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult> CreateWork(CreateWorkCommand command) => Ok(await _mediator.Send(command));

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateWork(int id, UpdateWorkCommand command)
        {
            if (id != command.Id)
            {
                return NotFound();
            }

            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWork(int id)
        {
            DeleteWorkCommand command = new DeleteWorkCommand(id);

            return Ok(await _mediator.Send(command));
        }
    }
}
