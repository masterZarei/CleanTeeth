using CleanTeeth.Application.Notifications;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace CleanTeeth.Infrastructure.Notifications
{
    public class EmailService : INotifications
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendAppointmentConfirmation(AppointmentConfirmationDTO appointmentConfirmationDTO)
        {
            var subject = "Appointment Confirmation - Clean Teeth";
            var body = $"""
                Dear, {appointmentConfirmationDTO.Patient},

                Your appointment with Dr. {appointmentConfirmationDTO.Dentist} has been scheduled for {appointmentConfirmationDTO.Date} in the office {appointmentConfirmationDTO.DentalOffice}.

                We will be waiting for you.

                Clean Teeth team
                """;

            await SendEmail(appointmentConfirmationDTO.Patient_Email, subject, body);
        }

        public async Task SendAppointmentReminder(AppointmentReminderDTO appointmentReminderDTO)
        {
            var subject = "Appointment Reminder - Clean Teeth";
            var body = $"""
                Dear {appointmentReminderDTO.Patient},

                This is a reminder for your appointment with Dr. {appointmentReminderDTO.Dentist} on {appointmentReminderDTO.Date.ToString("f")} in the office {appointmentReminderDTO.DentalOffice}.

                We will be waiting for you.

                Clean Teeth team
                """;

            await SendEmail(appointmentReminderDTO.Patient_Email, subject, body);
        }

        private async Task SendEmail(string to, string subject, string body)
        {
            var from = _configuration.GetValue<string>("EMAIL_CONFIGURATIONS:EMAIL");
            var password = _configuration.GetValue<string>("EMAIL_CONFIGURATIONS:PASSWORD");
            var host = _configuration.GetValue<string>("EMAIL_CONFIGURATIONS:HOST");
            var port = _configuration.GetValue<int>("EMAIL_CONFIGURATIONS:PORT");

            var smtpClient = new SmtpClient(host, port);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(from, password);

            var message = new MailMessage(from!, to, subject, body);
            await smtpClient.SendMailAsync(message);
        }
    }
}
