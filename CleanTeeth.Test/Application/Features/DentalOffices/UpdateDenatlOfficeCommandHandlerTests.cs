using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Features.DentalOffices.Commands.UpdateDentalOffice;
using CleanTeeth.Domain.Entities;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;

namespace CleanTeeth.Test.Application.Features.DentalOffices
{
    [TestClass]
    public class UpdateDenatlOfficeCommandHandlerTests
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private IDentalOfficeRepository repository;
        private IUnitOfWork unitOfWork;
        private UpdateDentalOfficeCommandHandler handler;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        [TestInitialize]
        public void Setup()
        {
            repository = Substitute.For<IDentalOfficeRepository>();
            unitOfWork = Substitute.For<IUnitOfWork>();
            handler = new UpdateDentalOfficeCommandHandler(repository, unitOfWork);
        }

        [TestMethod]
        public async Task Handle_WhenDentalOfficeExists_EntityIsUpdatedAndPersisted()
        {
            var dentalOffice = new DentalOffice("Dental Office A");
            var id = dentalOffice.Id;
            var command = new UpdateDentalOfficeCommand { Id = id, Name = "New Name" };

            repository.GetById(id).Returns(dentalOffice);

            await handler.Handle(command);
            await repository.Received(1).Update(dentalOffice);
            await unitOfWork.Received(1).Commit();
        }

        [TestMethod]
        public async Task Handle_WhenDentalOfficeDoesNotExists_Throws()
        {
            var command = new UpdateDentalOfficeCommand { Id = Guid.NewGuid(), Name = "New Name" };
            repository.GetById(command.Id).ReturnsNull();
            await Assert.ThrowsAsync<NotFoundException>(async () =>
             await handler.Handle(command)
             );
        }

        [TestMethod]
        public async Task Handle_WhenThereIsAnExceptionWhileUpdating_RollbackIsCalled()
        {
            var dentalOffice = new DentalOffice("Dental Office A");
            var id = dentalOffice.Id;
            var command = new UpdateDentalOfficeCommand { Id = id, Name = "New Name" };

            repository.GetById(id).Returns(dentalOffice);
            repository.Update(dentalOffice).Throws(new InvalidOperationException("Exception"));

            await Assert.ThrowsAsync<InvalidOperationException>(() => handler.Handle(command));
            await unitOfWork.Received(1).RollBack();
        }

    }
}
