using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Utilities;
using CleanTeeth.Application.Utilities.Common;

namespace CleanTeeth.Application.Features.Dentists.Queries.GetDentistList
{
    public class GetDentistListQueryHandler : IRequestHandler<GetDentistListQuery, PaginatedDTO<DentistListDTO>>
    {
        private readonly IDentistRepository _dentistRepository;

        public GetDentistListQueryHandler(IDentistRepository dentistRepository)
        {
            _dentistRepository = dentistRepository;
        }
        public async Task<PaginatedDTO<DentistListDTO>> Handle(GetDentistListQuery request)
        {
            var dentists = await _dentistRepository.GetFiltered(request);
            var totalAmountOfRecords = await _dentistRepository.GetTotalAmountOfRecords();
            var dentistDTO = dentists.Select(s=>s.ToDTO()).ToList();

            var paginatedDTO = new PaginatedDTO<DentistListDTO>
            {
                Elements = dentistDTO,
                TotalAmountOfRecords = totalAmountOfRecords
            };
            return paginatedDTO;
        }
    }
}
