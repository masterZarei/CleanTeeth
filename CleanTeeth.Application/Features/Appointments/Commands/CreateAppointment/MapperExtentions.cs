using CleanTeeth.Application.Notifications;
using CleanTeeth.Domain.Entities;

namespace CleanTeeth.Application.Features.Appointments.Commands.CreateAppointment
{
    internal static class MapperExtentions
    {
        internal static AppointmentConfirmationDTO ToDTO(this Appointment appointment)
        {
            return new AppointmentConfirmationDTO
            {
                Id = appointment.Id,
                Date = appointment.TimeInterval.Start,
                Patient = appointment.Patient!.Name,
                Patient_Email = appointment.Patient!.Email.Value,
                DentalOffice = appointment.DentalOffice!.Name,
                Dentist = appointment.Dentist!.Name,
            };
        }
    }
}
