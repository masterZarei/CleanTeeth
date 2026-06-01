using CleanTeeth.Application.Utilities;
using Microsoft.Extensions.DependencyInjection;

namespace CleanTeeth.Application
{
    public static class RegisterApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IMediator, SimpleMediator>();

            services.Scan(scan => scan.FromAssembliesOf(typeof(RegisterApplicationServices))
            .AddClasses(c => c.AssignableTo(typeof(IRequestHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime()
            .AddClasses(c => c.AssignableTo(typeof(IRequestHandler<,>)))
            .AsImplementedInterfaces().WithScopedLifetime());

            //services.AddScoped<IRequestHandler<CreateDentalOfficeCommand, Guid>,
            //    CreateDentalOfficeHandler>();

            //services.AddScoped<IRequestHandler<GetDentalOfficeDetailQuery, DentalOfficeDetailDTO>,
            //    GetDentalOfficeDetailQueryHandler>();

            //services.AddScoped<IRequestHandler<GetDentalOfficesListQuery, List<DentalOfficesListDTO>>,
            //    GetDentalOfficesListQueryHandler>();

            //services.AddScoped<IRequestHandler<UpdateDentalOfficeCommand>,
            //    UpdateDentalOfficeCommandHandler>();

            //services.AddScoped<IRequestHandler<DeleteDentalOfficeCommand>,
            //    DeleteDentalOfficeCommandHandler>();
            return services;
        }
    }
}
