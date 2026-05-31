using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Features.DentalOffices.Commands.DeleteDentalOffice;
using CleanTeeth.Domain.Entities;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;

namespace CleanTeeth.Test.Application.Features.DentalOffices
{
    [TestClass]
    public class DeleteDentalOfficeCommandHandlerTests
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private IDentalOfficeRepository repository;
        private IUnitOfWork unitOfWork;
        private DeleteDentalOfficeCommandHandler handler;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        [TestInitialize]
        public void Setup()
        {
            repository = Substitute.For<IDentalOfficeRepository>();
            unitOfWork = Substitute.For<IUnitOfWork>();
            handler = new DeleteDentalOfficeCommandHandler(repository, unitOfWork);
        }

        [TestMethod]
        public async Task Handle_WhenDentalOfficeExists_DeleteAndCommitAreCalled()
        {
            var dentalOffice = new DentalOffice("Dental Office A");
            var command = new DeleteDentalOfficeCommand { Id = dentalOffice.Id };

            repository.GetById(command.Id).Returns(dentalOffice);
            await handler.Handle(command);

            await repository.Received(1).Delete(dentalOffice);
            await unitOfWork.Received(1).Commit();
        }

        [TestMethod]
        public async Task Handle_WhenDentalOfficeDoesNotExist_Throws()
        {
            var command = new DeleteDentalOfficeCommand { Id = Guid.NewGuid() };
            repository.GetById(command.Id).ReturnsNull();
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(command);
            });
        }

        [TestMethod]
        public async Task Handle_WhenAnExceptionOccursWhileUpdating_RollbackIsCalled()
        {
            var dentalOffice = new DentalOffice("Dental Office A");
            var command = new DeleteDentalOfficeCommand { Id = dentalOffice.Id };

            repository.GetById(command.Id).Returns(dentalOffice);
            repository.Delete(dentalOffice).Throws(new InvalidOperationException());

            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await handler.Handle(command);
            });
            await unitOfWork.Received(1).RollBack();
        }
    }
}
