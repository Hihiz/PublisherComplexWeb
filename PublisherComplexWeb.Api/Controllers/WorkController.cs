using Microsoft.AspNetCore.Mvc;

namespace PublisherComplexWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        private readonly IWorkService _workService;

        public WorkController(IWorkService workService) => (_workService) = (workService);

        [HttpGet]
        public async Task<ActionResult> GetWorks() => Ok(await _workService.GetAll());     
    }
}
