using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.BLL.ServiceInjections
{
    public static class CustumSessionService
    {
        public static IServiceCollection AddSessionServices(this IServiceCollection services)
        {

            services.AddSession(x =>
            {
                x.IdleTimeout = TimeSpan.FromMinutes(30);
                x.Cookie.HttpOnly = true;                    //document.cookie'den ilgili bilginin gözlemlenmesi
                x.Cookie.IsEssential = true;                 // GDPR uyumluluğu için gerekli
            });

            return services;
        }


    }
}
