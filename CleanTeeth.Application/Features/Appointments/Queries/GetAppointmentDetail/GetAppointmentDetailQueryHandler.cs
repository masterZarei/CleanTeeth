using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Utilities;

namespace CleanTeeth.Application.Features.Appointments.Queries.GetAppointmentDetail
{
    public class GetAppointmentDetailQueryHandler : IRequestHandler<GetAppointmentDetailQuery, AppointmentDetailDTO>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GetAppointmentDetailQueryHandler(IAppointmentRepository appointmentRepository, IUnitOfWork unitOfWork)
        {
            _appointmentRepository = appointmentRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<AppointmentDetailDTO> Handle(GetAppointmentDetailQuery request)
        {
            var appointment = await _appointmentRepository.GetById(request.Id) ?? throw new NotFoundException();
            return appointment.ToDTO();
        }
    }
}
