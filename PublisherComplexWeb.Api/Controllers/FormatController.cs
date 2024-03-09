using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublisherComplexWeb.Application.Dto.Format;
using PublisherComplexWeb.Application.Interfaces;
using PublisherComplexWeb.Application.Validations.FluentValidations.Format;

using ValidationResult = FluentValidation.Results.ValidationResult;

namespace PublisherComplexWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormatController : ControllerBase
    {
        private readonly IFormatService _formatService;

        public FormatController(IFormatService formatService) => _formatService = formatService;

        [HttpGet]
        public async Task<ActionResult> GetFormats() => Ok(await _formatService.GetAll());

        [HttpGet("{id}")]
        public async Task<ActionResult> GetFormat(int id) => Ok(await _formatService.GetById(id));

        //[Authorize(Roles = "Member, Admin")]
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CreateFormat(CreateFormatDto dto)
        {
            CreateFormatValidator validators = new CreateFormatValidator();

            ValidationResult result = validators.Validate(dto);

            if (!result.IsValid)
            {
                return BadRequest(string.Join('\n', result.Errors));
            }

            return Ok(await _formatService.CreateFormat(dto));
        }

        //[Authorize(Roles = "Member, Admin")]
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateFormat(int id, UpdateFormatDto dto)
        {
            UpdateFormatValidator validators = new UpdateFormatValidator();

            ValidationResult result = validators.Validate(dto);

            if (!result.IsValid)
            {
                return BadRequest(string.Join('\n', result.Errors));
            }

            return Ok(await _formatService.UpdateFormat(id, dto));
        }

        //[Authorize(Roles = "Admin")]
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFormat(int id)
        {
            await _formatService.DeleteFormat(id);

            return Ok(id);
        }
    }
}
