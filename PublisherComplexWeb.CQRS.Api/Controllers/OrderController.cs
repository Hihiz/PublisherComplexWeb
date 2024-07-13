namespace PublisherComplexWeb.CQRS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {        
        public OrderController(IMediator mediator, ApplicationDbContext db) => (_mediator, _db) = (mediator, db);

        [HttpGet]
        public async Task<ActionResult> GetOrders()
        {
           
        }

        [HttpGet("orderOpen")]
        public async Task<ActionResult> GetOrderOpen()
        {
        
        }

        [HttpGet("orderClose")]
        public async Task<ActionResult> GetOrderClose()
        {

        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetOrder(int id)
        {
          
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder(CreateOrderCommand command)

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrder(int id, UpdateOrderCommand command)
        {
           
        }
    }
}
