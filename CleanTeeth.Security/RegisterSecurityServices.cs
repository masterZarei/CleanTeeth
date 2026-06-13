using CleanTeeth.Application.Contracts.Security.CleanTeeth.Application.Contracts.Security;
using CleanTeeth.Security.Models;
using CleanTeeth.Security.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanTeeth.Security
{
    public static class RegisterSecurityServices
    {
        public static void AddSecurityService(this IServiceCollection services)
        {
            services.AddAuthentication(IdentityConstants.BearerScheme).AddBearerToken(IdentityConstants.BearerScheme);
            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("isadmin", policy => policy.RequireClaim("isadmin"));
            });

            services.AddDbContext<CleanTeethSecurityDbContext>(options =>
            {
                options.UseSqlServer("name=CleanTeethConnectionString");
            });

            services.AddIdentityCore<User>()
                .AddEntityFrameworkStores<CleanTeethSecurityDbContext>()
                .AddApiEndpoints();

            services.AddTransient<IUserService, UserService>();
            services.AddHttpContextAccessor();
        }
    }
}
