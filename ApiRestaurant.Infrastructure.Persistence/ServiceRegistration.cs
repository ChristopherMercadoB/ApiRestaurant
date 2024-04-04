using ApiRestaurant.Core.Application.Interfaces.Repositories;
using ApiRestaurant.Infrastructure.Persistence.Context;
using ApiRestaurant.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurant.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            #region Context
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationContext>(op=>op.UseInMemoryDatabase("InMemoryDb"));
            }
            else
            {
                services.AddDbContext<ApplicationContext>(op=>op.UseSqlServer(configuration
                    .GetConnectionString("DefaultConnection"), m=>
                        m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
            }
            #endregion

            #region Repositories

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IDishRepository, DishRepository>();
            services.AddTransient<IDishIngredientRepository, DishIngredientRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<ITableRepository, TableRepository>();
            services.AddTransient<IIngredientRepository, IngredientRepository>();
            services.AddTransient<IOrderDishRepository, OrderDishRepository>();

            #endregion
        }
    }
}
