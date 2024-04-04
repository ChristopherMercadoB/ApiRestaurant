using ApiRestaurant.Core.Application.Interfaces.Services;
using ApiRestaurant.Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace ApiRestaurant.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddCoreApplication(this IServiceCollection services)
        {
            #region AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            #endregion

            #region Services
            services.AddTransient(typeof(IGenericService<,,>), typeof(GenericService<,,>));
            services.AddTransient<IDishService, DishService>();
            services.AddTransient<IIngredientService, IngredientService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<ITableService, TableService>();
            #endregion
        }
    }
}
