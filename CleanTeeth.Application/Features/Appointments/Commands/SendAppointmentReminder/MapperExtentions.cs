using CleanTeeth.Application.Notifications;
using CleanTeeth.Domain.Entities;

namespace CleanTeeth.Application.Features.Appointments.Commands.SendAppointmentReminder
{
    internal static class MapperExtentions
    {
        internal static AppointmentReminderDTO ToDTO(this Appointment appointment)
        {
            return new AppointmentReminderDTO
            {
                Id = appointment.Id,
                Date = appointment.TimeInterval.Start,
                Patient = appointment.Patient!.Name,
                Patient_Email = appointment.Patient!.Email.Value,
                Dentist = appointment.Dentist!.Name,
                DentalOffice = appointment.DentalOffice!.Name
            };
        }
    }
}
