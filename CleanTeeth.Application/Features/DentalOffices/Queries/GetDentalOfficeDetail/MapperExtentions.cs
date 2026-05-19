namespace CleanTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail
{
    internal static class MapperExtentions
    {
        public static DentalOfficeDetailDTO MapToDentalOfficeDetailDto(this Domain.Entities.DentalOffice dentalOffice)
        {
            return new DentalOfficeDetailDTO
            {
                Id = dentalOffice.Id,
                Name = dentalOffice.Name,
            };
        }
    }
}
