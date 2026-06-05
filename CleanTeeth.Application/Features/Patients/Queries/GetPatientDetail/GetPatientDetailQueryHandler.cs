using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Utilities;

namespace CleanTeeth.Application.Features.Patients.Queries.GetPatientDetail
{
    public class GetPatientDetailQueryHandler : IRequestHandler<GetPatientDetailQuery, PatientDetailDTO>
    {
        private readonly IPatientRepository _patientRepository;

        public GetPatientDetailQueryHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public async Task<PatientDetailDTO> Handle(GetPatientDetailQuery request)
        {

            var patient = await _patientRepository.GetById(request.Id) ?? throw new NotFoundException();
            return patient.ToDTO();
        }
    }
}
