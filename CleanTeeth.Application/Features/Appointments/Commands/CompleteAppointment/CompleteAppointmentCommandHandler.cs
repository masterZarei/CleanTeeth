using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Utilities;

namespace CleanTeeth.Application.Features.Appointments.Commands.CompleteAppointment
{
    public class CompleteAppointmentCommandHandler : IRequestHandler<CompleteAppointmentCommand>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CompleteAppointmentCommandHandler(IAppointmentRepository appointmentRepository, IUnitOfWork unitOfWork)
        {
            _appointmentRepository = appointmentRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(CompleteAppointmentCommand request)
        {
            var appointment = await _appointmentRepository.GetById(request.Id) ?? throw new NotFoundException();
            appointment.Complete();
            try
            {
                await _appointmentRepository.Update(appointment);
                await _unitOfWork.Commit();
            }
            catch (Exception)
            {
                await _unitOfWork.RollBack();
                throw;
            }
        }
    }
}
