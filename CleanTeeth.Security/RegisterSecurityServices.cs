using CleanTeeth.Security.Models;
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
            services.AddAuthorization();

            services.AddDbContext<CleanTeethSecurityDbContext>(options =>
            {
                options.UseSqlServer("name=CleanTeethSecurityConnectionString");
            });

            services.AddIdentityCore<User>()
                .AddEntityFrameworkStores<CleanTeethSecurityDbContext>()
                .AddApiEndpoints();
        }
    }
}
