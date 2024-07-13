namespace PublisherComplexWeb.CQRS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MaterialController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult> GetMaterials()
        {
          
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetMaterial(int id)
        {
        
        }

        [HttpPost]
        public async Task<ActionResult> CreateMaterial(CreateMaterialCommand command) 

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMaterial(int id, UpdateMaterialCommand command)
        {
            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMaterial(int id)
        {
        }
    }
}
