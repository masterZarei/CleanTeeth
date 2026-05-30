using CleanTeeth.Application.Features.DentalOffices.Commands.CreateDentailOffice;
using CleanTeeth.Application.Features.DentalOffices.Commands.DeleteDentalOffice;
using CleanTeeth.Application.Features.DentalOffices.Commands.UpdateDentalOffice;
using CleanTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;
using CleanTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficesList;
using CleanTeeth.Application.Utilities;
using Microsoft.Extensions.DependencyInjection;

namespace CleanTeeth.Application
{
    public static class RegisterApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IMediator, SimpleMediator>();
            services.AddScoped<IRequestHandler<CreateDentalOfficeCommand, Guid>,
                CreateDentalOfficeHandler>();

            services.AddScoped<IRequestHandler<GetDentalOfficeDetailQuery, DentalOfficeDetailDTO>,
                GetDentalOfficeDetailQueryHandler>();

            services.AddScoped<IRequestHandler<GetDentalOfficesListQuery, List<DentalOfficesListDTO>>,
                GetDentalOfficesListQueryHandler>();

            services.AddScoped<IRequestHandler<UpdateDentalOfficeCommand>,
                UpdateDentalOfficeCommandHandler>();

            services.AddScoped<IRequestHandler<DeleteDentalOfficeCommand>,
                DeleteDentalOfficeCommandHandler>();
            return services;
        }
    }
}
