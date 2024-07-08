using PublisherComplexWeb.Application.Dto.Format;

namespace PublisherComplexWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormatController : ControllerBase
    {
        private readonly IBaseService<FormatDto, CreateFormatDto, UpdateFormatDto> _formatService;

        public FormatController(IBaseService<FormatDto, CreateFormatDto, UpdateFormatDto> formatService) => _formatService = formatService;

        [HttpGet]
        public async Task<ActionResult> GetFormats() => Ok(await _formatService.GetAll());
    }
}
