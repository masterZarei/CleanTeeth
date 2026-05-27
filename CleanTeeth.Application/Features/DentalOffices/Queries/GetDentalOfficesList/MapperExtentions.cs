using CleanTeeth.Domain.Entities;

namespace CleanTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficesList
{
    internal static class MapperExtentions
    {
        public static DentalOfficesListDTO ToDTO(this DentalOffice dentalOffice)
        {
            var dto = new DentalOfficesListDTO
            {
                Id = dentalOffice.Id,
                Name = dentalOffice.Name,
            };
            return dto;
        }
    }
}
