using CleanTeeth.Domain.Entities;

namespace CleanTeeth.Application.Features.Dentists.Queries.GetDentistDetail
{
    internal static class MapperExtentions
    {
        internal static DentistDetailDTO ToDTO(this Dentist dentist)
        {
            return new DentistDetailDTO
            {
                Id = dentist.Id,
                Name = dentist.Name,
                Email = dentist.Email.Value
            };
        }
    }
}
