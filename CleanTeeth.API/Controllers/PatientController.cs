using CleanTeeth.API.DTOs.Patients;
using CleanTeeth.API.Utilities;
using CleanTeeth.Application.Features.Patients.Commands.CreatePatient;
using CleanTeeth.Application.Features.Patients.Queries.GetPatientsList;
using CleanTeeth.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace CleanTeeth.API.Controllers
{
    [ApiController]
    [Route("api/patients")]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<PatientListDTO>>> Get([FromQuery] GetPatientsListQuery query)
        {
            var result = await _mediator.Send(query);
            HttpContext.InsertPaginationsInformationInHeader(result.TotalAmountOfRecords);
            return result.Elements;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreatePatientDTO createPatientDTO)
        {
            var command = new CreatePatientCommand
            {
                Name = createPatientDTO.Name,
                Email = createPatientDTO.Email,
            };
            await _mediator.Send(command);
            return Ok();
        }
    }
}
