using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Features.Patients.Commands.CreatePatient;
using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.ValueObjects;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace CleanTeeth.Test.Application.Features.Patients
{
    [TestClass]
    public class CretePatientCommandHandlerTests
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private IPatientRepository _patientRepository;
        private IUnitOfWork _unitOfWork;
        private CreatePatientCommandHandler _handler;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        [TestInitialize]
        public void Setup()
        {
            _patientRepository = Substitute.For<IPatientRepository>();
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _handler = new CreatePatientCommandHandler(_patientRepository, _unitOfWork);
        }

        [TestMethod]
        public async Task Handle_ValidCommand_ReturnsPatientId()
        {
            var command = new CreatePatientCommand { Name = "test", Email = "test@example.com" };
            var patient = new Patient(command.Name, new EmailValueObject(command.Email));

            _patientRepository.Add(Arg.Any<Patient>()).Returns(patient);

            var result = await _handler.Handle(command);

            Assert.AreEqual(patient.Id, result);
            await _patientRepository.Received(1).Add(Arg.Any<Patient>());
            await _unitOfWork.Received(1).Commit();
        }

        [TestMethod]
        public async Task Handle_WhenTheresAnError_RollbackIsCalled()
        {
            var command = new CreatePatientCommand { Name = "test", Email = "test@example.com" };
            _patientRepository.Add(Arg.Any<Patient>()).Throws<Exception>();

            await Assert.ThrowsAsync<Exception>(async () => await _handler.Handle(command));

            await _unitOfWork.Received(1).RollBack();

        }
    }
}
