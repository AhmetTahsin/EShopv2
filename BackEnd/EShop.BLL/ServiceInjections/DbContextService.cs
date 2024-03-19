using EShop.DAL.ContextClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.BLL.ServiceInjections
{
    public static class DbContextService
    {
        public static IServiceCollection AddDbContextService(this IServiceCollection services)
        {

            ServiceProvider provider = services.BuildServiceProvider();
            
            IConfiguration? configuration = provider.GetService<IConfiguration>();

            services.AddDbContextPool<MyContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("MyConnection")).UseLazyLoadingProxies());

            return services;

        }
    }
}
