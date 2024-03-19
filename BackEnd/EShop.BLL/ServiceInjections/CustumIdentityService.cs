using EShop.DAL.ContextClasses;
using EShop.ENTITIES.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.BLL.ServiceInjections
{
    public static class CustumIdentityService
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {

            services.AddIdentity<AppUser, IdentityRole<int>>(x =>
            {
                x.Password.RequireDigit = false;        //Şifrede Sayı kullanma zorunlulugu yok testlerden sonra bu ayarlamalar değiştirilmeli !
                x.Password.RequireUppercase = false;    //büyük harf 
                x.Password.RequireLowercase = false;    //küçük harf 
                x.Password.RequiredLength = 2;          //Şifre uzunluğu min
                x.SignIn.RequireConfirmedEmail = true;      // E-Posta onayı için Mail Servisi yazılacak o yüzden açtım
                x.Password.RequireNonAlphanumeric = false;  //özel karakter kullanma

            }).AddEntityFrameworkStores<MyContext>().AddDefaultTokenProviders();


            return services;
        }
    }
}
