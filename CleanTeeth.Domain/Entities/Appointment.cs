using CleanTeeth.Domain.Enums;
using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Domain.Entities
{
    public class Appointment
    {
        public Guid Id { get; private set; }
        public Guid PatientId { get; private set; }
        public Guid DentistId { get; private set; }
        public Guid DentalOfficeId { get; private set; }
        public AppointmentStatusEnum Status { get; private set; }
        public TimeIntervalValueObject TimeInterval { get; private set; }
        public Patient? Patient { get; private set; }
        public Dentist? Dentist { get; private set; }
        public DentalOffice? DentalOffice { get; private set; }

        public Appointment(Guid patientId, Guid dentistId, Guid dentalOfficesId, TimeIntervalValueObject timeInterval)
        {
            if (timeInterval.Start < DateTime.UtcNow)
            {
                throw new BusinessRuleException("The start time cannot be in the past");
            }

            PatientId = patientId;
            DentistId = dentistId;
            DentalOfficeId = dentalOfficesId;
            TimeInterval = timeInterval;
            Status = AppointmentStatusEnum.Scheduled;
            Id = Guid.CreateVersion7();
        }
        public void Cancel()
        {
            if (Status != AppointmentStatusEnum.Scheduled)
            {
                throw new BusinessRuleException("Only scheduled appoinments can be cancelled");
            }
            Status = AppointmentStatusEnum.Cancelled;
        }
        public void Complete()
        {
            if (Status != AppointmentStatusEnum.Scheduled)
            {
                throw new BusinessRuleException("Only scheduled appoinments can be completed");
            }
            Status = AppointmentStatusEnum.Completed;
        }
    }
}