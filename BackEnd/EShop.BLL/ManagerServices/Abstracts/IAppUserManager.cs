using EShop.BLL.DTOs.DTOClasesses;
using EShop.ENTITIES.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.BLL.ManagerServices.Abstracts
{
    public interface IAppUserManager:IManager<AppUserRegisterDTO,AppUser>
    {
        public Task<string> AddUser(AppUserRegisterDTO appUser);
        public Task<string> LoginUser(AppUserLoginDTO appUserDTO);
        public Task<string> ConfirmUserEmail(Guid specId, int id);
        public Task<bool> SendPasswordResetEmailAsync(AppUserResetPasswordDTO appUserDTO);
        public string ResetPasswordLink();
        public Task<bool> UserPasswordReset(NewPasswordViewDTO passwordDTO);
        public void SignOutAsyncUser();
        
    }
}
