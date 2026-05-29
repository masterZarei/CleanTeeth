using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Utilities;

namespace CleanTeeth.Application.Features.DentalOffices.Commands.UpdateDentalOffice
{
    public class UpdateDentalOfficeCommandHandler : IRequestHandler<UpdateDentalOfficeCommand>
    {
        private readonly IDentalOfficeRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public UpdateDentalOfficeCommandHandler(IDentalOfficeRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }
        public async Task Handle(UpdateDentalOfficeCommand request)
        {
            var dentalOffice = await repository.GetById(request.Id) ?? throw new NotFoundException();
            dentalOffice.UpdateName(request.Name);
            try
            {
                await repository.Update(dentalOffice);
                await unitOfWork.Commit();
            }
            catch
            {

                await unitOfWork.RollBack();
                throw;
            }
        }
    }
}
