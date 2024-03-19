using EShop.BLL.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.BLL.ServiceInjections
{
    public static class CustumMapperService
    {
        public static void MapperServiceInjections(this IServiceCollection services)
        {
            services.AddAutoMapper(x => x.AddProfile(typeof(EShopMapper)));
        }
    }
}
