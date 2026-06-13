using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Utilities;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Application.Features.Dentists.Commands.UpdateDentist
{
    public class UpdateDentistCommandHandler : IRequestHandler<UpdateDentistCommand>
    {
        private readonly IDentistRepository _dentistRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDentistCommandHandler(IDentistRepository dentistRepository, IUnitOfWork unitOfWork)
        {
            _dentistRepository = dentistRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(UpdateDentistCommand request)
        {
            var dentist = await _dentistRepository.GetById(request.Id) ?? throw new NotFoundException();
            dentist.UpdateName(request.Name);
            var email = new EmailValueObject(request.Email);
            dentist.UpdateEmail(email);

            try
            {
                await _dentistRepository.Update(dentist);
                await _unitOfWork.Commit();
            }
            catch
            {
                await _unitOfWork.RollBack();
                throw;
            }
        }
    }
}
