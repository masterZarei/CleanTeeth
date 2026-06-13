using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Notifications;
using CleanTeeth.Application.Utilities;
using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Application.Features.Appointments.Commands.CreateAppointment
{
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, Guid>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotifications _notifications;

        public CreateAppointmentCommandHandler(IAppointmentRepository appointmentRepository,
            IUnitOfWork unitOfWork, INotifications notifications)
        {
            _appointmentRepository = appointmentRepository;
            _unitOfWork = unitOfWork;
            _notifications = notifications;
        }
        public async Task<Guid> Handle(CreateAppointmentCommand request)
        {
            var existsOverlap = await _appointmentRepository.OverlapExists(request.DentistId, request.StartDate, request.EndDate);
            if (existsOverlap)
            {
                throw new CustomValidationException("The dentist has an appointment at the selected time");
            }
            var timeInterval = new TimeIntervalValueObject(request.StartDate, request.EndDate);
            var appointment = new Appointment(request.PatientId, request.DentistId, request.DentalOfficeId, timeInterval);

            Guid? id = null;
            try
            {
                var result = await _appointmentRepository.Add(appointment);
                await _unitOfWork.Commit();
                id = result.Id;
            }
            catch (Exception)
            {
                await _unitOfWork.RollBack();
                throw;
            }
            var appointmentData = await _appointmentRepository.GetById(id.Value);
            var notificationDTO = appointmentData!.ToDTO();
            await _notifications.SendAppointmentConfirmation(notificationDTO);

            return id.Value;

        }
    }
}
