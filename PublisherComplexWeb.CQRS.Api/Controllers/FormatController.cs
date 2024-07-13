using MediatR;
using Microsoft.AspNetCore.Mvc;

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
            List<FormatDto> formmats = await _mediator.Send(query);

            return Ok(formmats);
        }
    }
}
