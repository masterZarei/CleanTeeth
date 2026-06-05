using FluentValidation;

namespace CleanTeeth.Application.Features.Patients.Commands.UpdatePatient
{
    public class UpdatePatientCommandValidation : AbstractValidator<UpdatePatientCommand>
    {
        public UpdatePatientCommandValidation()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("The field {PropertyName} is required");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("The field {PropertyName} is required")
                .EmailAddress().WithMessage("Invalid email format");
        }
    }
}
