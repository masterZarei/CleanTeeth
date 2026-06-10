using FluentValidation.Results;

namespace CleanTeeth.Application.Exceptions
{
    public class CustomValidationException : Exception
    {
        public List<string> ValidationErrors { get; set; } = [];
        public CustomValidationException(string errorMessages)
        {
            ValidationErrors.Add(errorMessages);
        }

        public CustomValidationException(ValidationResult validationResult)
        {
            foreach (var validationError in validationResult.Errors)
            {
                ValidationErrors.Add(validationError.ErrorMessage);
            }
        }
    }
}
