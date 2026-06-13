using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Utilities;
using FluentValidation;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace CleanTeeth.Test.Application.Utilities.Mediator
{
    [TestClass]
    public class SimpleMediatorTests
    {
        public class FalseRequest : IRequest<string>
        {
            public required string Name { get; set; }
        }
        public class FalseRequestValidator : AbstractValidator<FalseRequest>
        {
            public FalseRequestValidator()
            {
                RuleFor(x => x.Name).NotEmpty();
            }
        }

        [TestMethod]
        public async Task Send_WithRegisteredHandler_HandlerIsExecuted()
        {
            var request = new FalseRequest() { Name = "test" };
            var handlerMock = Substitute.For<IRequestHandler<FalseRequest, string>>();
            var serviceProviderMock = Substitute.For<IServiceProvider>();

            serviceProviderMock
                .GetService(typeof(IRequestHandler<FalseRequest, string>)).
                Returns(handlerMock);

            var mediator = new SimpleMediator(serviceProviderMock);
            var result = await mediator.Send(request);
            await handlerMock.Received(1).Handle(request);
        }
        [TestMethod]
        public async Task Send_WithoutRegisteredHandler_Throws()
        {
            var request = new FalseRequest() { Name = "test" };
            var serviceProviderMock = Substitute.For<IServiceProvider>();
            serviceProviderMock
                .GetService(typeof(IRequestHandler<FalseRequest, string>)).
                ReturnsNull();

            var mediator = new SimpleMediator(serviceProviderMock);
            await Assert.ThrowsAsync<MediatorException>(async () =>
            {
                await mediator.Send(request);
            });
        }
        [TestMethod]
        public async Task Send_InvalidCommand_Throws()
        {
            var request = new FalseRequest() { Name = "" };
            var serviceProviderMock = Substitute.For<IServiceProvider>();
            var validator = new FalseRequestValidator();

            serviceProviderMock
                .GetService(typeof(IValidator<FalseRequest>))
                .Returns(validator);

            var mediator = new SimpleMediator(serviceProviderMock);
            await Assert.ThrowsAsync<CustomValidationException>(async () =>
            {
                await mediator.Send(request);
            });
        }
    }
}
