using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublisherComplexWeb.Application.Dto.Work;
using PublisherComplexWeb.Application.Interfaces;
using PublisherComplexWeb.Application.Validations.FluentValidations.Work;

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

        [HttpGet("workDetail/{id}")]
        public async Task<ActionResult> GetWork(int id) => Ok(await _workService.GetById(id));

        [HttpGet("{orderId}")]
        public async Task<ActionResult> GetWorksOrder(int orderId) => Ok(await _workService.GetByWorksOrder(orderId));

        //[Authorize(Roles = "Member, Admin")]
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CreateWork(CreateWorkDto dto)
        {
            CreateWorkValidator validators = new CreateWorkValidator();

            ValidationResult result = validators.Validate(dto);

            if (!result.IsValid)
            {
                return BadRequest(string.Join('\n', result.Errors));
            }

            return Ok(await _workService.CreateWork(dto));
        }

        //[Authorize(Roles = "Member, Admin")]
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateWork(int id, UpdateWorkDto dto)
        {
            UpdateWorkValidator validators = new UpdateWorkValidator();

            ValidationResult result = validators.Validate(dto);

            if (!result.IsValid)
            {
                return BadRequest(string.Join('\n', result.Errors));
            }

            return Ok(await _workService.UpdateWork(id, dto));
        }

        //[Authorize(Roles = "Admin")]
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> WorkDelete(int id)
        {
            await _workService.DeleteWork(id);

            return Ok(id);
        }
    }
}
