using CleanTeeth.Application.Features.Dentists.Queries.GetDentistList;
using CleanTeeth.Domain.Entities;

namespace CleanTeeth.Application.Contracts.Repositories
{
    public interface IDentistRepository : IRepository<Dentist>
    {
        Task<IEnumerable<Dentist>> GetFiltered(DentistFilterDTO filter);
    }
}
