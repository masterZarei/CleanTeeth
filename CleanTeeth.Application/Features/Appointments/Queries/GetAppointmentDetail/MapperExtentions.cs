using CleanTeeth.Domain.Entities;

namespace CleanTeeth.Application.Features.Appointments.Queries.GetAppointmentDetail
{
    internal static class MapperExtentions
    {
        internal static AppointmentDetailDTO ToDTO(this Appointment appointment)
        {
            return new AppointmentDetailDTO
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
