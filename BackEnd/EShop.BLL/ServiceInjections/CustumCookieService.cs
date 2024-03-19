using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.BLL.ServiceInjections
{
    public static class CustumCookieService
    {
        public static IServiceCollection AddCookieServices(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(x =>
            {
                x.Cookie.HttpOnly = true; //document.cookie yazılınca cookiler gozukmesin ! js erişemez
                x.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;//SSH sertifikası var ise !!
                x.Cookie.Name = "EShopCookie";  //Cookie adı !
                x.ExpireTimeSpan = TimeSpan.FromMinutes(5);//Cookie 5 dk sonra geçerliliğini kaybetsin !
                x.Cookie.SameSite = SameSiteMode.Strict;//Aynı siteden gozukur sadece cookie başka sitede gözükmesin
                x.LoginPath = new PathString("/Home/LogIn"); //Giriş gerekern sayfalara ulasmak isterse bu sayfaya yönlendir 
                x.AccessDeniedPath = new PathString("/Home/Index"); //yetkisi yetmediği sayfaya gitmeye çalıştıgında buraya 
            });

            return services;
        }
    }
}
