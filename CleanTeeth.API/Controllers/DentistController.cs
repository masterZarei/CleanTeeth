using CleanTeeth.API.DTOs.Dentists;
using CleanTeeth.API.Utilities;
using CleanTeeth.Application.Features.Dentists.Commands.CreateDentist;
using CleanTeeth.Application.Features.Dentists.Queries.GetDentistList;
using CleanTeeth.Application.Features.Patients.Queries.GetPatientsList;
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
    }
}
