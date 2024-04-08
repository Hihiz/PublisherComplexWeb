using MediatR;
using Microsoft.AspNetCore.Mvc;
using PublisherComplexWeb.CQRS.Application.TypeWorks.Commands.CreateFormat;
using PublisherComplexWeb.CQRS.Application.TypeWorks.Commands.DeleteFormat;
using PublisherComplexWeb.CQRS.Application.TypeWorks.Commands.UpdateFormat;
using PublisherComplexWeb.CQRS.Application.TypeWorks.Queries.GetFormatDetail;
using PublisherComplexWeb.CQRS.Application.TypeWorks.Queries.GetFormatList;

namespace PublisherComplexWeb.CQRS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeWorkController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TypeWorkController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult> GetTypeWorks()
        {
            GetTypeWorkListQuery query = new GetTypeWorkListQuery();

            return Ok(await _mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetTypeWork(int id)
        {
            GetTypeWorkDetailQuery query = new GetTypeWorkDetailQuery(id);

            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult> CreateTypeWork(CreateTypeWorkCommand command) => Ok(await _mediator.Send(command));

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTypeWork(int id, UpdateTypeWorkCommand command)
        {
            if (id != command.Id)
            {
                return NotFound();
            }

            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTypeWork(int id)
        {
            DeleteTypeWorkCommand command = new DeleteTypeWorkCommand(id);

            return Ok(await _mediator.Send(command));
        }
    }
}
