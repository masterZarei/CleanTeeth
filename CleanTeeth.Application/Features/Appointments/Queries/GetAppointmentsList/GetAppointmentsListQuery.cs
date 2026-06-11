using CleanTeeth.Application.Utilities;

namespace CleanTeeth.Application.Features.Appointments.Queries.GetAppointmentsList
{
    public class GetAppointmentsListQuery : AppointmentsFilterDTO, IRequest<List<AppointmentsListDTO>>
    {
    }
}
