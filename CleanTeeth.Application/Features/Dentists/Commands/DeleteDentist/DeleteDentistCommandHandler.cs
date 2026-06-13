using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Utilities;

namespace CleanTeeth.Application.Features.Dentists.Commands.DeleteDentist
{
    public class DeleteDentistCommandHandler : IRequestHandler<DeleteDentistCommand>
    {
        private readonly IDentistRepository _dentistRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDentistCommandHandler(IDentistRepository dentistRepository, IUnitOfWork unitOfWork)
        {
            _dentistRepository = dentistRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(DeleteDentistCommand request)
        {
            var dentist = await _dentistRepository.GetById(request.Id) ?? throw new NotFoundException();
            try
            {
                await _dentistRepository.Delete(dentist);
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
