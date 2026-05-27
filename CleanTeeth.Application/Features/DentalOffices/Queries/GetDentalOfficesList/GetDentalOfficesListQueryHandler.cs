using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Utilities;

namespace CleanTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficesList
{
    public class GetDentalOfficesListQueryHandler :
        IRequestHandler<GetDentalOfficesListQuery, List<DentalOfficesListDTO>>
    {
        private readonly IDentalOfficeRepository repository;

        public GetDentalOfficesListQueryHandler(IDentalOfficeRepository repository)
        {
            this.repository = repository;
        }
        public async Task<List<DentalOfficesListDTO>> Handle(GetDentalOfficesListQuery request)
        {
            var dentalOffices = await repository.GetAll();
            var dentalOfficesDTO = dentalOffices.Select(dentalOffices=> dentalOffices.ToDTO()).ToList();
            return dentalOfficesDTO;
        }
    }
}
