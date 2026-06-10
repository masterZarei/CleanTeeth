using FluentValidation;

namespace CleanTeeth.Application.Features.Appointments.Commands.CreateAppointment
{
    public class CreateAppointmentCommandValidator : AbstractValidator<CreateAppointmentCommand>
    {
        public CreateAppointmentCommandValidator()
        {
            RuleFor(x => x.StartDate)
                .GreaterThan(x => x.EndDate).WithMessage("Start Date must be before end date");


        }
    }
}
