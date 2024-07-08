using PublisherComplexWeb.Application.Dto.Material;
using PublisherComplexWeb.Application.Interfaces.Services;

namespace PublisherComplexWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IBaseService<MaterialDto, CreateMaterialDto, UpdateMaterialDto> _materialService;

        public MaterialController(IBaseService<MaterialDto, CreateMaterialDto, UpdateMaterialDto> materialService) => _materialService = materialService;

        [HttpGet]
        public async Task<ActionResult> GetMaterials() => Ok(await _materialService.GetAll());
    }
}
