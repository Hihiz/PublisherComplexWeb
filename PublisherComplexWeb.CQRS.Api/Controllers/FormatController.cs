using MediatR;
using Microsoft.AspNetCore.Mvc;
using PublisherComplexWeb.CQRS.Application.Formats.Commands.CreateFormat;
using PublisherComplexWeb.CQRS.Application.Formats.Commands.DeleteFormat;
using PublisherComplexWeb.CQRS.Application.Formats.Commands.UpdateFormat;
using PublisherComplexWeb.CQRS.Application.Formats.Queries.GetFormatDetail;
using PublisherComplexWeb.CQRS.Application.Formats.Queries.GetFormatList;

namespace PublisherComplexWeb.CQRS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormatController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FormatController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult> GetFormats()
        {
            GetFormatListQuery query = new GetFormatListQuery();
            
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetFormat(int id)
        {
            GetFormatDetailQuery query = new GetFormatDetailQuery(id);
            
            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult> CreateFormat(CreateFormatCommand command) => Ok(await _mediator.Send(command));

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateFormat(int id, UpdateFormatCommand command)
        {
            if (id != command.Id)
            {
                return NotFound();
            }

            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFormat(int id)
        {
            DeleteFormatCommand command = new DeleteFormatCommand(id);

            return Ok(await _mediator.Send(command));
        }
    }
}
