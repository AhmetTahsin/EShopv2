using EShop.DAL.ContextClasses;
using EShop.DAL.Repositories.Abstracts;
using EShop.ENTITIES.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.DAL.Repositories.Concretes
{
    public class AppUserRepository:BaseRepository<AppUser>,IAppUserRepository
    {
        public AppUserRepository(MyContext db,UserManager<AppUser> userManager):base(db)
        {
            
        }

    }
}
