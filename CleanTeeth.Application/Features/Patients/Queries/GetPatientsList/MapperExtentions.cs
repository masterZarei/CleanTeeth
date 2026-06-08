using CleanTeeth.Domain.Entities;

namespace CleanTeeth.Application.Features.Patients.Queries.GetPatientsList
{
    internal static class MapperExtentions
    {
        internal static PatientListDTO ToDTO(this Patient patient)
        {
            return new PatientListDTO
            {
                Id = patient.Id,
                Name = patient.Name,
                Email = patient.Email.Value,
            };
        }
    }
}
