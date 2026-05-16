using FluentValidation;

namespace CleanTeeth.Application.Features.DentalOffices.Commands.CreateDentailOffice
{
    public class CreateDentalOfficeValidator : AbstractValidator<CreateDentailOfficeCommand>
    {
        public CreateDentalOfficeValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("The field {PropertyName} is required.");
        }
    }
}
