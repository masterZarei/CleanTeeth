using CleanTeeth.Application.Utilities;

namespace CleanTeeth.Application.Features.Appointments.Queries.GetAppointmentDetail
{
    public class GetAppointmentDetailQuery : IRequest<AppointmentDetailDTO>
    {
        public required Guid Id { get; set; }
    }
}
