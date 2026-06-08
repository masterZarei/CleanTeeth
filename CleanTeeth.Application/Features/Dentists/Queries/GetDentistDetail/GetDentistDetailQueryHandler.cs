using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Utilities;

namespace CleanTeeth.Application.Features.Dentists.Queries.GetDentistDetail
{
    public class GetDentistDetailQueryHandler : IRequestHandler<GetDentistDetailQuery, DentistDetailDTO>
    {
        private readonly IDentistRepository _dentistRepository;

        public GetDentistDetailQueryHandler(IDentistRepository dentistRepository)
        {
            _dentistRepository = dentistRepository;
        }
        public async Task<DentistDetailDTO> Handle(GetDentistDetailQuery request)
        {
            var dentist = await _dentistRepository.GetById(request.Id) ?? throw new NotFoundException();
            return dentist.ToDTO();
        }
    }
}
