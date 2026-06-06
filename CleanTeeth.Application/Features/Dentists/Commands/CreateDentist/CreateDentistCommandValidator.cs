using FluentValidation;

namespace CleanTeeth.Application.Features.Dentists.Commands.CreateDentist
{
    public class CreateDentistCommandValidator : AbstractValidator<CreateDentistCommand>
    {
        public CreateDentistCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("The field {PropertyName} is required");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("The field {PropertyName} is required")
                .EmailAddress().WithMessage("Invalid email format");
        }
    }
}
