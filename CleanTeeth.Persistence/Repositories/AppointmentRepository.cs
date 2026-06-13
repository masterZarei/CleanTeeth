using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Contracts.Repositories.Mdodels;
using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace CleanTeeth.Persistence.Repositories
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        private readonly CleanTeethDbContext _context;

        public AppointmentRepository(CleanTeethDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> OverlapExists(Guid dentistId, DateTime start, DateTime end)
        {
            return await _context.Appointments
                .Where(x => x.DentistId == dentistId && x.Status == AppointmentStatusEnum.Scheduled
                && start < x.TimeInterval.End && end > x.TimeInterval.Start).AnyAsync();
        }
        new public async Task<Appointment?> GetById(Guid id)
        {
            return await _context.Appointments
                .Include(x => x.Patient)
                .Include(x => x.Dentist)
                .Include(x => x.DentalOffice)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Appointment>> GetFiltered(AppointmentsFilterDTO appointmentsFilterDTO)
        {
            var queryable = _context.Appointments
                  .Include(x => x.Patient)
                  .Include(x => x.Dentist)
                  .Include(x => x.DentalOffice)
                  .AsQueryable();
            if (appointmentsFilterDTO.DentalOfficeId is not null)
            {
                queryable = queryable.Where(x => x.DentalOfficeId == appointmentsFilterDTO.DentalOfficeId);
            }
            if (appointmentsFilterDTO.PatientId is not null)
            {
                queryable = queryable.Where(x => x.PatientId == appointmentsFilterDTO.PatientId);
            }
            if (appointmentsFilterDTO.DentistId is not null)
            {
                queryable = queryable.Where(x => x.DentistId == appointmentsFilterDTO.DentistId);
            }
            if (appointmentsFilterDTO.AppointmentStatus is not null)
            {
                queryable = queryable.Where(x => x.Status == appointmentsFilterDTO.AppointmentStatus);
            }
            return await queryable.Where(x => x.TimeInterval.Start >= appointmentsFilterDTO.StartDate
            && x.TimeInterval.End <= appointmentsFilterDTO.EndDate)
                .OrderBy(x => x.TimeInterval.Start)
                .ToListAsync();
        }
    }
}
