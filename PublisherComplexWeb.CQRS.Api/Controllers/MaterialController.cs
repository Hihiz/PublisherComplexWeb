using MediatR;
using Microsoft.AspNetCore.Mvc;
using PublisherComplexWeb.CQRS.Application.Materials.Commands.CreateMaterial;
using PublisherComplexWeb.CQRS.Application.Materials.Commands.DeleteMaterial;
using PublisherComplexWeb.CQRS.Application.Materials.Commands.UpdateMaterial;
using PublisherComplexWeb.CQRS.Application.Materials.Queries.GetMaterialDetail;
using PublisherComplexWeb.CQRS.Application.Materials.Queries.GetMaterialList;

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
            GetMaterialListQuery query = new GetMaterialListQuery();
            
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetMaterial(int id)
        {
            GetMaterialDetailQuery query = new GetMaterialDetailQuery(id);
            
            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult> CreateMaterial(CreateMaterialCommand command) => Ok(await _mediator.Send(command));

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMaterial(int id, UpdateMaterialCommand command)
        {
            if (id != command.Id)
            {
                return NotFound();
            }

            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMaterial(int id)
        {
            DeleteMaterialCommand command = new DeleteMaterialCommand(id);

            return Ok(await _mediator.Send(command));
        }
    }
}
