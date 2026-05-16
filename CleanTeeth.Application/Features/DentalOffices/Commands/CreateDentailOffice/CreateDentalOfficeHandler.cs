using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Domain.Entities;

namespace CleanTeeth.Application.Features.DentalOffices.Commands.CreateDentailOffice
{
    public class CreateDentalOfficeHandler
    {
        private readonly IDentalOfficeRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public CreateDentalOfficeHandler(IDentalOfficeRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(CreateDentailOfficeCommand command)
        {
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
