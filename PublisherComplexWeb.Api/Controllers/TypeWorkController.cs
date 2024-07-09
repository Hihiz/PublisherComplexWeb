using PublisherComplexWeb.Application.Dto.TypeWork;
using PublisherComplexWeb.Application.Interfaces.Services;


namespace PublisherComplexWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeWorkController : ControllerBase
    {
        private readonly IBaseService<TypeWorkDto, CreateTypeWorkDto, UpdateTypeWorkDto> _typeWorkService;

        public TypeWorkController(IBaseService<TypeWorkDto, CreateTypeWorkDto, UpdateTypeWorkDto> materialService) => _typeWorkService = materialService;

        [HttpGet]
        public async Task<ActionResult> GetTypeWorks() => Ok(await _typeWorkService.GetAll());       
    }
}
