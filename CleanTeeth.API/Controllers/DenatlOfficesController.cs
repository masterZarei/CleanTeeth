using CleanTeeth.API.DTOs.DenatlOffices;
using CleanTeeth.Application.Features.DentalOffices.Commands.CreateDentailOffice;
using CleanTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;
using CleanTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficesList;
using CleanTeeth.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace CleanTeeth.API.Controllers
{
    [ApiController]
    [Route("api/dentaloffices")]
    public class DenatlOfficesController : Controller
    {
        private readonly IMediator mediator;

        public DenatlOfficesController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<DentalOfficeDetailDTO>>> GetAll()
        {
            var query = new GetDentalOfficesListQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDentalOfficeById(Guid id)
        {
            var query = new GetDentalOfficeDetailQuery { Id = id };
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDentalOffice([FromBody] CreateDentalOfficeDTO createDentalOfficeDTO)
        {
            var command = new CreateDentalOfficeCommand { Name= createDentalOfficeDTO.Name };
            var result = await mediator.Send(command);
            return Ok();
        }
    }
}
