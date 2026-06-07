using CleanTeeth.Domain.Entities;

namespace CleanTeeth.Application.Features.Dentists.Queries.GetDentistList
{
    public static class MapperExtentions
    {
        internal static DentistListDTO ToDTO(this Dentist dentist)
        {
            return new DentistListDTO
            {
                Id = dentist.Id,
                Name = dentist.Name,
                Email = dentist.Email.Value,
            };
        }
    }
}
