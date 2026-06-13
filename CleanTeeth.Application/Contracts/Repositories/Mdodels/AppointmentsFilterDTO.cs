using CleanTeeth.Domain.Enums;

namespace CleanTeeth.Application.Contracts.Repositories.Mdodels
{
    public class AppointmentsFilterDTO
    {
        public Guid? PatientId { get; set; }
        public Guid? DentistId { get; set; }
        public Guid? DentalOfficeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public AppointmentStatusEnum? AppointmentStatus { get; set; }
    }
}
