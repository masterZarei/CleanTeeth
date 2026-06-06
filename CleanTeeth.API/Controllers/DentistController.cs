using CleanTeeth.API.DTOs.Dentists;
using CleanTeeth.Application.Features.Dentists.Commands.CreateDentist;
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
