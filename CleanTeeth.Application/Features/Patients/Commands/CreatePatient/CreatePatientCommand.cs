using CleanTeeth.Application.Utilities;

namespace CleanTeeth.Application.Features.Patients.Commands.CreatePatient
{
    public class CreatePatientCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
