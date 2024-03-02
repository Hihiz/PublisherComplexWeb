using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using PublisherComplexWeb.Application.Dto.TypeWork;
using PublisherComplexWeb.Application.Interfaces;
using PublisherComplexWeb.Application.Validations.FluentValidations.TypeWork;

namespace PublisherComplexWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeWorkController : ControllerBase
    {
        private readonly ITypeWorkService _typeWorkService;

        public TypeWorkController(ITypeWorkService materialService) => _typeWorkService = materialService;

        [HttpGet]
        public async Task<ActionResult> GetTypeWorks() => Ok(await _typeWorkService.GetAll());

        [HttpGet("{id}")]
        public async Task<ActionResult> GetTypeWork(int id) => Ok(await _typeWorkService.GetById(id));

        [HttpPost]
        public async Task<ActionResult> CreateTypeWork(CreateTypeWorkDto dto)
        {
            CreateTypeWorkValidator validators = new CreateTypeWorkValidator();

            ValidationResult result = validators.Validate(dto);

            if (!result.IsValid)
            {
                return BadRequest(string.Join('\n', result.Errors));
            }

            return Ok(await _typeWorkService.CreateTypeWork(dto));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTypeWork(int id, UpdateTypeWorkDto dto)
        {
            UpdateTypeWorkValidator validators = new UpdateTypeWorkValidator();

            ValidationResult result = validators.Validate(dto);

            if (!result.IsValid)
            {
                return BadRequest(string.Join('\n', result.Errors));
            }

            return Ok(await _typeWorkService.UpdateTypeWork(id, dto));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTypeWork(int id)
        {
            await _typeWorkService.DeleteTypeWork(id);

            return Ok(id);
        }
    }
}
