using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Utilities;
using CleanTeeth.Application.Utilities.Common;

namespace CleanTeeth.Application.Features.Patients.Queries.GetPatientsList
{
    public class GetPatientsListQueryHandler : IRequestHandler<GetPatientsListQuery, PaginatedDTO<PatientListDTO>>
    {
        private readonly IPatientRepository _patientRepository;

        public GetPatientsListQueryHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public async Task<PaginatedDTO<PatientListDTO>> Handle(GetPatientsListQuery request)
        {
            var patients = await _patientRepository.GetFiltered(request);
            var totalAmountOfRecords = await _patientRepository.GetTotalAmountOfRecords();
            var patientsDTO = patients.Select(patient=>patient.ToDTO()).ToList();

            var paginatedDTO = new PaginatedDTO<PatientListDTO>
            {
                Elements = patientsDTO,
                TotalAmountOfRecords = totalAmountOfRecords
            };

            return paginatedDTO;
        }
    }
}
