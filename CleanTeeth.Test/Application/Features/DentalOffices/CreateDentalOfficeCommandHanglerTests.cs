using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Features.DentalOffices.Commands.CreateDentailOffice;
using CleanTeeth.Domain.Entities;
using NSubstitute;

namespace CleanTeeth.Test.Application.Features.DentalOffices
{
    [TestClass]
    public class CreateDentalOfficeCommandHanglerTests
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private IDentalOfficeRepository repository;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private IUnitOfWork unitOfWork;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private CreateDentalOfficeHandler handler;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        [TestInitialize]
        public void Initialize()
        {
            repository = Substitute.For<IDentalOfficeRepository>();
            unitOfWork = Substitute.For<IUnitOfWork>();
            handler = new CreateDentalOfficeHandler(repository, unitOfWork);
        }

        [TestMethod]
        public async Task Handle_ValidCommand_ReturnsDentalOfficeId()
        {
            var command = new CreateDentalOfficeCommand
            {
                Name = "Test Dental Office"
            };
            var dentalOffice = new DentalOffice("DentalOffice A");
            repository.Add(Arg.Any<DentalOffice>()).Returns(dentalOffice);

            var result = await handler.Handle(command);
            await repository.Received(1).Add(Arg.Any<DentalOffice>());
            await unitOfWork.Received(1).Commit();
            Assert.AreEqual(dentalOffice.Id, result);
        }

        [TestMethod]
        public async Task Handle_WhenTheresAnError_RollbackHappens()
        {
            var command = new CreateDentalOfficeCommand
            {
                Name = "Test Dental Office"
            };
            repository.When(x => x.Add(Arg.Any<DentalOffice>())).Do(x => { throw new Exception("Database error"); });
            await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(command));
            await unitOfWork.Received(1).RollBack();
        }
    }
}
