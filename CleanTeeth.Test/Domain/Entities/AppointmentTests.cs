using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.Enums;
using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Test.Domain.Entities
{
    [TestClass]
    public class AppointmentTests
    {
        private Guid _patientId = Guid.NewGuid();
        private Guid _dentistId = Guid.NewGuid();
        private Guid _dentalOfficeId = Guid.NewGuid();
        private TimeIntervalValueObject _interval = new TimeIntervalValueObject(DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddDays(2));

        [TestMethod]
        public void Constructor_ValidAppointment_StatusIsScheduled()
        {
            var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, _interval);

            Assert.AreEqual(_patientId, appointment.PatientId);
            Assert.AreEqual(_dentistId, appointment.DentistId);
            Assert.AreEqual(_dentalOfficeId, appointment.DentalOfficeId);
            Assert.AreEqual(_interval, appointment.TimeInterval);
            Assert.AreEqual(AppointmentStatusEnum.Scheduled, appointment.Status);
            Assert.AreNotEqual(Guid.Empty, appointment.Id);
        }

        [TestMethod]
        public void Constructor_StartTimeInThePast_Throws()
        {
            Assert.Throws<BusinessRuleException>(() =>
            {
                var interval = new TimeIntervalValueObject(DateTime.UtcNow.AddDays(-1), DateTime.UtcNow);
                new Appointment(_patientId, _dentistId, _dentalOfficeId, interval);
            });

        }

        [TestMethod]
        public void Cancel_CancellingAppointment_ChangesStatusToCancelled()
        {
            var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, _interval);
            appointment.Cancel();
            Assert.AreEqual(AppointmentStatusEnum.Cancelled, appointment.Status);
        }

        [TestMethod]
        public void Cancel_CancellingAppointment_ThrowsIfStatusIsNotScheduled()
        {
            Assert.Throws<BusinessRuleException>(() =>
            {
                var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, _interval);
                appointment.Cancel();
                appointment.Cancel();
            });

        }

        [TestMethod]
        public void Complete_CompletingAppointment_ChangesStatusToCompleted()
        {
            var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, _interval);
            appointment.Complete();
            Assert.AreEqual(AppointmentStatusEnum.Completed, appointment.Status);
        }

        [TestMethod]
        public void Complete_CompletingAppointment_ThrowsIfStatutsIsNotScheduled()
        {
            Assert.Throws<BusinessRuleException>(() =>
            {
                var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, _interval);
                appointment.Cancel();
                appointment.Complete();
            });
        }
    }
}
