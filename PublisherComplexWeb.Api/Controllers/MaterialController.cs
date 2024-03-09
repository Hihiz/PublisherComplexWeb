using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublisherComplexWeb.Application.Dto.Material;
using PublisherComplexWeb.Application.Interfaces;
using PublisherComplexWeb.Application.Validations.FluentValidations.Material;

namespace PublisherComplexWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService _materialService;

        public MaterialController(IMaterialService materialService) => _materialService = materialService;

        [HttpGet]
        public async Task<ActionResult> GetMaterials() => Ok(await _materialService.GetAll());

        [HttpGet("{id}")]
        public async Task<ActionResult> GetMaterial(int id) => Ok(await _materialService.GetById(id));

        //[Authorize(Roles = "Member, Admin")]
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CreateMaterial(CreateMaterialDto dto)
        {
            CreateMaterialValidator validators = new CreateMaterialValidator();

            ValidationResult result = validators.Validate(dto);

            if (!result.IsValid)
            {
                return BadRequest(string.Join('\n', result.Errors));
            }

            return Ok(await _materialService.CreateMaterial(dto));
        }

        //[Authorize(Roles = "Member, Admin")]
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMaterial(int id, UpdateMaterialDto dto)
        {
            UpdateMaterialValidator validators = new UpdateMaterialValidator();

            ValidationResult result = validators.Validate(dto);

            if (!result.IsValid)
            {
                return BadRequest(string.Join('\n', result.Errors));
            }

            return Ok(await _materialService.UpdateMaterial(id, dto));
        }

        //[Authorize(Roles = "Admin")]
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMaterial(int id)
        {
            await _materialService.DeleteMaterial(id);

            return Ok(id);
        }
    }
}
