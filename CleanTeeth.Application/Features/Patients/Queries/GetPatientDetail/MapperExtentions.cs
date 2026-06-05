using CleanTeeth.Domain.Entities;

namespace CleanTeeth.Application.Features.Patients.Queries.GetPatientDetail
{
    internal static class MapperExtentions
    {
        internal static PatientDetailDTO ToDTO(this Patient patient)
        {
            return new PatientDetailDTO
            {
                Id = patient.Id,
                Name = patient.Name,
                Email = patient.Email.Value
            };
        }
    }
}
