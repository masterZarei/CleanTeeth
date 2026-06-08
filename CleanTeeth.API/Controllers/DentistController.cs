using CleanTeeth.API.DTOs.Dentists;
using CleanTeeth.API.Utilities;
using CleanTeeth.Application.Features.Dentists.Commands.CreateDentist;
using CleanTeeth.Application.Features.Dentists.Commands.DeleteDentist;
using CleanTeeth.Application.Features.Dentists.Commands.UpdateDentist;
using CleanTeeth.Application.Features.Dentists.Queries.GetDentistDetail;
using CleanTeeth.Application.Features.Dentists.Queries.GetDentistList;
using CleanTeeth.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace CleanTeeth.API.Controllers
{
    [ApiController]
    [Route("api/dentists")]
    public class DentistController : Controller
    {
        private readonly IMediator _mediator;

        public DentistController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<DentistListDTO>>> Get([FromQuery] GetDentistListQuery query)
        {
            var result = await _mediator.Send(query);
            HttpContext.InsertPaginationsInformationInHeader(result.TotalAmountOfRecords);
            return result.Elements;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DentistDetailDTO>> Get(Guid id)
        {
            var query = new GetDentistDetailQuery { Id = id };
            return await _mediator.Send(query);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDentist([FromBody] CreateDentistDTO createDentistDTO)
        {
            var command = new CreateDentistCommand
            {
                Name = createDentistDTO.Name,
                Email = createDentistDTO.Email,
            };
            await _mediator.Send(command);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, UpdateDentistDTO updateDentistDTO)
        {
            var command = new UpdateDentistCommand
            {
                Id = id,
                Name = updateDentistDTO.Name,
                Email = updateDentistDTO.Email,
            };
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteDentistCommand
            {
                Id = id,
            };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
