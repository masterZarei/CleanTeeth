using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Contracts.Repositories.Mdodels;
using CleanTeeth.Application.Notifications;
using CleanTeeth.Application.Utilities;

namespace CleanTeeth.Application.Features.Appointments.Commands.SendAppointmentReminder
{
    public class SendAppointmentReminderCommandHandler : IRequestHandler<SendAppointmentReminderCommand>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly INotifications _notifications;

        public SendAppointmentReminderCommandHandler(IAppointmentRepository appointmentRepository, INotifications notifications)
        {
            _appointmentRepository = appointmentRepository;
            _notifications = notifications;
        }
        public async Task Handle(SendAppointmentReminderCommand request)
        {
            var startDate = DateTime.Now.Date.AddDays(1);
            var endDate = startDate.AddDays(1);
            var filter = new AppointmentsFilterDTO
            {
                StartDate = startDate,
                EndDate = endDate,
                AppointmentStatus = Domain.Enums.AppointmentStatusEnum.Scheduled
            };

            var appointments = await _appointmentRepository.GetFiltered(filter);
            foreach (var appointment in appointments)
            {
                var dto = appointment.ToDTO();
                await _notifications.SendAppointmentReminder(dto);
            }
        }
    }
}
