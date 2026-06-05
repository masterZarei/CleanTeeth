using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Utilities;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Application.Features.Patients.Commands.UpdatePatient
{
    public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePatientCommandHandler(IPatientRepository patientRepository, IUnitOfWork unitOfWork)
        {
            _patientRepository = patientRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(UpdatePatientCommand request)
        {
            var patient = await _patientRepository.GetById(request.Id) ?? throw new NotFoundException();

            patient.UpdateName(request.Name);
            var email = new EmailValueObject(request.Email);
            patient.UpdateEmail(email);

            try
            {
                await _patientRepository.Update(patient);
                await _unitOfWork.Commit();
            }
            catch (Exception)
            {
                await _unitOfWork.RollBack();
                throw;
                throw;
            }

        }
    }
}
