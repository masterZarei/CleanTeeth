using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Utilities;
using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Application.Features.Patients.Commands.CreatePatient
{
    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, Guid>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePatientCommandHandler(IPatientRepository patientRepository, IUnitOfWork unitOfWork)
        {
            _patientRepository = patientRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(CreatePatientCommand request)
        {
            var email = new EmailValueObject(request.Email);
            var patient = new Patient(request.Name, email);

            try
            {
                var result = await _patientRepository.Add(patient);
                await _unitOfWork.Commit();
                return result.Id;
            }
            catch
            {
                await _unitOfWork.RollBack();
                throw;
            }
        }
    }
}
