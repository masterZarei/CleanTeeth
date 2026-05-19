using CleanTeeth.Application.Utilities;

namespace CleanTeeth.Application.Features.DentalOffices.Commands.CreateDentailOffice
{
    public class CreateDentailOfficeCommand : IRequest<Guid>
    {
        public required string Name { get; set; }
    }
}
