using AutoMapper;
using EShop.BLL.DTOs.DTOClasesses;
using EShop.BLL.ManagerServices.Abstracts;
using EShop.COMMON.Tools;
using EShop.DAL.Repositories.Abstracts;
using EShop.ENTITIES.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace EShop.BLL.ManagerServices.Concretes
{
    public class AppUserManager:BaseManager<AppUserRegisterDTO,AppUser>,IAppUserManager
    {
        IAppUserRepository _appUseRep;
        IMapper _mapper;
        readonly UserManager<AppUser> _appUserManager;
        readonly SignInManager<AppUser> _signInManager;
        public AppUserManager(IAppUserRepository appUserRep, IMapper mapper, UserManager<AppUser> appUserManager, SignInManager<AppUser> signInManager) : base(appUserRep, mapper)
        {
            _appUseRep = appUserRep;
            _mapper = mapper;
            _appUserManager = appUserManager;
            _signInManager = signInManager;
        }

        public async Task<string> AddUser(AppUserRegisterDTO appUserDTO) 
        {

            AppUser user = new AppUser()
            {
                 UserName = appUserDTO.UserName,
                 Email = appUserDTO.Email,
            };

            IdentityResult result = await _appUserManager.CreateAsync(user,appUserDTO.Password);

            if(result.Succeeded)
            {
                await _appUserManager.AddToRoleAsync(user, "Member");
                return user.Id.ToString();
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    if (error.Description.Contains("Email"))
                    {
                        return "Email";
                    }
                    else if (error.Description.Contains("UserName"))
                    {
                        return "UserName";
                    }
                    else
                    {
                        return "Fail";
                    }
                }
            }
            return "Fail";

        }



        public async Task<string> LoginUser(AppUserLoginDTO appUserDTO)
        {
            AppUser appUser = await _appUserManager.FindByNameAsync(appUserDTO.UserName);
            if (appUser == null)
            {
                return "NoFound";
            }
            SignInResult result = await _signInManager.PasswordSignInAsync(appUser, appUserDTO.Password,appUserDTO.RememberMe,true);

            if (result.Succeeded) //Todo: Yeni Role Olur ise buraya ekleme yap string donen degerlere göre Controller'a yaz
            {
                IList<string> role = await _appUserManager.GetRolesAsync(appUser);
                if (role.Contains("Admin"))
                {
                    return "Admin";
                }
                else if (role.Contains("Member"))
                {
                    return "Member";
                }
                else if (role.Contains("Seller"))
                {
                    return "Seller";
                }
            }
            else if (result.IsNotAllowed)//Mail onayı lazım
            {
                return "MailPanel";
            }
            return "NoFound";
        }

        public async Task<string> ConfirmUserEmail(Guid specId, int id)
        {
            AppUser appUser = await _appUserManager.FindByIdAsync(id.ToString());
            if(appUser == null)
            {
                return "Kullanıcı Bulunamadı.";
            }
            appUser.EmailConfirmed = true;
            await _appUserManager.UpdateAsync(appUser);
            return "Email Başarı ile onaylandı giriş yapabilirsiniz.";
        }
        string _veri;
        public string ResetPasswordLink() //Mail ayarları yapılı değilse diye !!
        {
            return _veri;
        }

        public async Task<bool> SendPasswordResetEmailAsync(AppUserResetPasswordDTO appUserDTO)
        {
            var user = await _appUserManager.FindByEmailAsync(appUserDTO.Email);
            if (user == null)
            {
                return false;
            }

            var resetToken = await _appUserManager.GeneratePasswordResetTokenAsync(user);
            var resetLink = $"http://localhost:5102/Home/NewPassword?userId={user.Id}&token={Uri.EscapeDataString(resetToken)}";
            _veri = resetLink; //Mail ayarları yapılı değilse diye !!
            string subject = "EShop Şifre Sıfırlama";
            string body = $"Şifrenizi sıfırlamak için linke tıklayınız: {resetLink}";

            // Mail gönderme işlemi
            MailService.Send(user.Email, body: body, subject: subject);

            return true;
        }
        public async Task<bool> UserPasswordReset(NewPasswordViewDTO passwordDTO)
        {
            AppUser user = await _appUserManager.FindByIdAsync(passwordDTO.UserId.ToString());

            if (user == null)
            {
                return false;
            }

            user.ModifiedDate = DateTime.Now;
            
            IdentityResult resetResult = await _appUserManager.ResetPasswordAsync(user, passwordDTO.Token, passwordDTO.Password);
            
            if(resetResult.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public async void SignOutAsyncUser()
        {
            var a=_signInManager.SignOutAsync();
        }
    }
}
