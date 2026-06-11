using CleanTeeth.Application.Contracts.Repositories;
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
    }
}
