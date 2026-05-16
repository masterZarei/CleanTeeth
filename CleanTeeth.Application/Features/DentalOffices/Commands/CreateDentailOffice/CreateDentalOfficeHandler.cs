using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Domain.Entities;
using FluentValidation;

namespace CleanTeeth.Application.Features.DentalOffices.Commands.CreateDentailOffice
{
    public class CreateDentalOfficeHandler
    {
        private readonly IDentalOfficeRepository repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IValidator<CreateDentailOfficeCommand> validator;

        public CreateDentalOfficeHandler(IDentalOfficeRepository repository, IUnitOfWork unitOfWork, IValidator<CreateDentailOfficeCommand> validator)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.validator = validator;
        }
        public async Task<Guid> Handle(CreateDentailOfficeCommand command)
        {
            var validationResult = await validator.ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                throw new CustomValidationException(validationResult);
            }

            var dentalOffice = new DentalOffice(command.Name);
            try
            {
                var result = await repository.Add(dentalOffice);
                await unitOfWork.Commit();
                return result.Id;
            }
            catch (Exception)
            {
                await unitOfWork.RollBack();
                throw;
            }
            
        }
    }
}
