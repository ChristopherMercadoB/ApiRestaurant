using ApiRestaurant.Core.Application.Enums;
using ApiRestaurant.Infrastructure.Identity;

namespace ApiRestaurant.WebApp.WebApi.Configurations
{
    public static class AddRolesConfiguration
    {
        public static void ConfigureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddInfrastructureIdentity(configuration);
            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdminRole", policy =>
                    policy.RequireRole("Admin"));

                options.AddPolicy("RequireWaiterRole", policy =>
                    policy.RequireRole("Waiter"));

                options.AddPolicy("RequireAdminOrWaiterRole", policy =>
                    policy.RequireRole("Admin", "Waiter"));
            });
        }
    }
}
