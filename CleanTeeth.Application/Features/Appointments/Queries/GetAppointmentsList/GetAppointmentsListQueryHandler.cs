using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Utilities;

namespace CleanTeeth.Application.Features.Appointments.Queries.GetAppointmentsList
{
    public class GetAppointmentsListQueryHandler : IRequestHandler<GetAppointmentsListQuery, List<AppointmentsListDTO>>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        public GetAppointmentsListQueryHandler(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }


        public async Task<List<AppointmentsListDTO>> Handle(GetAppointmentsListQuery request)
        {
            var appointments = await _appointmentRepository.GetFiltered(request);
            var appointmentsDTO = appointments.Select(appointment => appointment.ToDTO()).ToList();
            return appointmentsDTO;
        }
    }
}
