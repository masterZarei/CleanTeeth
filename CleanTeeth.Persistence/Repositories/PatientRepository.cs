using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Features.Patients.Queries.GetPatientsList;
using CleanTeeth.Domain.Entities;
using CleanTeeth.Persistence.Utilities;
using Microsoft.EntityFrameworkCore;

namespace CleanTeeth.Persistence.Repositories
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        private readonly CleanTeethDbContext _context;

        public PatientRepository(CleanTeethDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Patient>> GetFiltered(PatientsFilterDTO filter)
        {
            var queryable = _context.Patients.AsQueryable();
            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                queryable = queryable.Where(q => q.Name.Contains(filter.Name));
            }
            if (!string.IsNullOrWhiteSpace(filter.Email))
            {
                queryable = queryable.Where(q => q.Email.Value.Contains(filter.Email));
            }

            return await queryable.OrderBy(x => x.Name).Paginate(filter.Page, filter.RecordsPerPage)
                .ToListAsync();
        }
    }
}
