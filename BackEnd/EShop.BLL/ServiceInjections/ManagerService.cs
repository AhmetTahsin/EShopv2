using EShop.BLL.DTOs.CoreInterfaces;
using EShop.BLL.ManagerServices.Abstracts;
using EShop.BLL.ManagerServices.Concretes;
using EShop.ENTITIES.CoreInterfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.BLL.ServiceInjections
{
    public static class ManagerService
    {
        public static IServiceCollection AddManagerServices(this IServiceCollection services)
        {

            services.AddScoped(typeof(IManager<,>), typeof(BaseManager<,>));

            services.AddScoped<ICategoryManager, CategoryManager>();
            services.AddScoped<IAppUserManager, AppUserManager>();
            services.AddScoped<IProductManager, ProductManager>();
            services.AddScoped<IOrderManager, OrderManager>();
            services.AddScoped<IOrderDetailManager, OrderDetailManager>();
            services.AddScoped<IAppUserProfileManager, AppUserProfileManager>();

            //services.AddAutoMapper(typeof(ServiceCollectionExtensions));

            return services;
        }

    }
}
