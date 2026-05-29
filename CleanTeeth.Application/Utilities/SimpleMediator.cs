using CleanTeeth.Application.Exceptions;
using FluentValidation;

namespace CleanTeeth.Application.Utilities
{
    public class SimpleMediator : IMediator
    {
        private readonly IServiceProvider serviceProvider;

        public SimpleMediator(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
        {

            await ApplyValidation(request);
            var handlerType = typeof(IRequestHandler<,>)
                .MakeGenericType(request.GetType(), typeof(TResponse));

            var handler = serviceProvider.GetService(handlerType);

            if (handler == null)
            {
                throw new MediatorException($"Handler was not found for {request.GetType().Name}");
            }
            var method = handlerType.GetMethod("Handle");
            return await (Task<TResponse>)method.Invoke(handler, [request]);
        }

        public async Task Send(IRequest request)
        {
            await ApplyValidation(request);

            var handlerType = typeof(IRequestHandler<>).MakeGenericType(request.GetType());
            var handler = serviceProvider.GetService(handlerType);
            if (handler is null) 
            {
                throw new MediatorException($"Handler was not found for {request.GetType().Name}");
            }

            var method = handlerType.GetMethod("Handle");
            await (Task)method.Invoke(handler, [request])!;

        }
        private async Task ApplyValidation(object request)
        {
            var validatorType = typeof(IValidator<>)
               .MakeGenericType(request.GetType());
            var validator = serviceProvider.GetService(validatorType) as IValidator;
            if (validator is not null)
            {
                var validateMethod = validatorType.GetMethod("ValidateAsync");
                var taskToValidate = (Task)validateMethod.Invoke(validator, [request, default(CancellationToken)])!;

                await taskToValidate;
                var resultProperty = taskToValidate.GetType().GetProperty("Result");
                var validationResult = resultProperty.GetValue(taskToValidate) as FluentValidation.Results.ValidationResult;

                if (!validationResult.IsValid)
                {
                    throw new CustomValidationException(validationResult);
                }
            }
        }
    }
}
