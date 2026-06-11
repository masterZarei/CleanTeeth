using CleanTeeth.Domain.Entities;

namespace CleanTeeth.Application.Features.Appointments.Queries.GetAppointmentsList
{
    internal static class MapperExtentions
    {
        internal static AppointmentsListDTO ToDTO(this Appointment appointment)
        {
            return new AppointmentsListDTO
            {
                Id = appointment.Id,
                StartDate = appointment.TimeInterval.Start,
                EndDate = appointment.TimeInterval.End,
                Patinet = appointment.Patient!.Name,
                Dentist = appointment.Dentist!.Name,
                DentalOffice = appointment.DentalOffice!.Name,
                Status = appointment.Status.ToString()
            };
        }
    }
}
