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
           
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetTypeWork(int id)
        {
          
        }

        [HttpPost]
        public async Task<ActionResult> CreateTypeWork(CreateTypeWorkCommand command)

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTypeWork(int id, UpdateTypeWorkCommand command)
        {
           
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTypeWork(int id)
        {

        }
    }
}
