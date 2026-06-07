using CleanTeeth.Application.Utilities;
using CleanTeeth.Application.Utilities.Common;

namespace CleanTeeth.Application.Features.Dentists.Queries.GetDentistList
{
    public class GetDentistListQuery : DentistFilterDTO, IRequest<PaginatedDTO<DentistListDTO>>
    {
    }
}
