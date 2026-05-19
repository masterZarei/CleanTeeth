using CleanTeeth.Application.Exceptions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
