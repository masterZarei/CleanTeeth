using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Utilities;

namespace CleanTeeth.Application.Features.Patients.Queries.GetPatientsList
{
    public class GetPatientsListQueryHandler : IRequestHandler<GetPatientsListQuery, List<PatientListDTO>>
    {
        private readonly IPatientRepository _patientRepository;

        public GetPatientsListQueryHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public async Task<List<PatientListDTO>> Handle(GetPatientsListQuery request)
        {
            var patients = await _patientRepository.GetAll();
            var patientsDTO = patients.Select(patient=>patient.ToDTO()).ToList();
            return patientsDTO;
        }
    }
}
