using EShop.BLL.DTOs.DTOClasesses;
using EShop.BLL.ManagerServices.Abstracts;
using EShop.COMMON.Tools;
using EShop.COREMVC.Models;
using EShop.COREMVC.Models.PageModels.LoginUserModels;
using EShop.COREMVC.Models.PageModels.NewPasswordUserModels;
using EShop.COREMVC.Models.PageModels.RegisterUserModels;
using EShop.COREMVC.Models.PageModels.ResetUserModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Diagnostics;
using X.PagedList;

namespace EShop.COREMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly IAppUserManager _appUserManager;
        readonly ICategoryManager _categoryManager;
        readonly IProductManager _productManager;
        public HomeController(ILogger<HomeController> logger, IAppUserManager appUserManager, ICategoryManager categoryManager, IProductManager productManager)
        {
            _logger = logger;
            _appUserManager = appUserManager;
            _categoryManager = categoryManager;
            _productManager = productManager;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult LogIn()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Admin")) //Yerine Area ismini string olarak geri veren bir metod yaz�labilir b�ylelikle if else u�ra�may�z
                    return RedirectToAction("Index", "Home", new { Area = "Admin" });
                else if (User.IsInRole("Member"))
                {
                    return RedirectToAction("Index", "Home", new { Area = "Member" });
                }
                else if (User.IsInRole("Seller"))
                {
                    return RedirectToAction("Index", "Home", new { Area = "Seller" });
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(UserLoginPageVM model)
        {

            AppUserLoginDTO userDTO = new AppUserLoginDTO()
            {
                UserName = model.User.UserName.ToLower(),
                Password = model.User.Password,
                RememberMe = model.User.RememberMe,
            };

            string result = await _appUserManager.LoginUser(userDTO); 
            #region Rol Kontrol
            if (result == "Admin")
            {
                return RedirectToAction("Index", "Home", new { Area = "Admin" }); //Todo: Area ismini string olarak veren metod yaz�lacak if elseden kurtulmak i�in get'te de post'ta da Role ve Area isimleri ayn� olacak �ekilde ayarl�yorum
            }
            else if (result == "Member")
            {
                return RedirectToAction("Index", "Home", new { Area = "Member" });
            }
            else if (result == "Seller")
            {
                return RedirectToAction("Index", "Home", new { Area = "Seller" });
            }
            #endregion
            #region EMail Onay
            else if (result == "MailPanel")
            {
                TempData["message"] = "E-Posta adresiniz ile mailinizi onay�n�z...";
                return RedirectToAction("LogIn");
            }
            #endregion
            #region Giri� Ba�ar�s�z
            else if (result == "NoFound")
            {
                TempData["message"] = "UserName veya Password Hatal�...";
                return RedirectToAction("LogIn");
            } 
            #endregion

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterPageVM model)
        {
            if (ModelState.IsValid) //model gelmi�se
            {
                AppUserRegisterDTO appUserDTO = new AppUserRegisterDTO()
                {
                    UserName = model.RegisterModel.UserName.ToLower(),
                    Password = model.RegisterModel.Password,
                    Email = model.RegisterModel.Email.ToLower(),
                };
                var result = await _appUserManager.AddUser(appUserDTO); //Mail ayarlamar� yap�l� de�ilse diye string olarak yazd�m normalde bool yapmak daha iyi olabilirdi AddUser'i !

                if (result == "Fail") //  Kullan�c� olusamad� ise UserName ve Email harici bir hata da !
                {
                    TempData["message"] = "Kullan�c� Olusamad� Site Y�neticisi ile ileti�ime ge�iniz";
                    return RedirectToAction("Register");
                }
                else if (result == "UserName")
                {
                    TempData["message"] = "Kullan�c� Ad� Daha �nce Al�nm�� veya ge�ersiz";
                    return RedirectToAction("Register");
                }
                else if (result == "Email")
                {
                    TempData["message"] = "Email Adresi Daha �nce Al�nm��";
                    return RedirectToAction("Register");
                }
                else //Bir hata olmad� ise geriye string tipte bir say� d�ndurecek id'yi ! result !
                {
                    Guid specId = Guid.NewGuid();
                    string subject = "EShop Mail Do�rulama";
                    string body = $"Hesab�n�z olusturulmustur.�yeliginizi onaylamak icin l�tfen http://localhost:5102/Home/ConfirmEmail?specId={specId}&id={result} linkine t�klay�n�z"; //olusturdu�muz link ile ConfirmEmail Actionuna gidecek �ifreli bir �ekilde 
                    MailService.Send(model.RegisterModel.Email, body: body, subject: subject); //Mail G�nder

                    //Smtp e-posta ayarlamalar� laz�m de�ilse diye linki burada g�steriyorum
                    TempData["message"] = $"Emailinizi kontrol ediniz //// Smtp ayarlar� yap�l� de�il ise T�kla => {body}";
                    return RedirectToAction("Register");
                }
            }
            return View(model);


        }

        public async Task<IActionResult> ConfirmEmail(Guid specId, int id)  
        {
            TempData["message"] = await _appUserManager.ConfirmUserEmail(specId, id);
            return RedirectToAction("Register");
        }
        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(UserResetPasswordPageVM model)
        {   //AppUser ile ilgili i�lemleri sadece AppUserDTO �zerinden yap�yoruz !
            AppUserResetPasswordDTO userDTO = new AppUserResetPasswordDTO()
            {
                Email=model.UserModel.Email,
            };

            if (await _appUserManager.SendPasswordResetEmailAsync(userDTO))
            {
                TempData["message"] = _appUserManager.ResetPasswordLink(); //mail ayarlar� yap�l� de�ilse diye linki g�rmek i�in 
                return View(model);
            }
            else
            {
                TempData["message"] = "Kullan�c� Bulunamad�";
                return View(model);
            }

        }
        public IActionResult NewPassword(int userId, string token)
        {
            return View(new NewPasswordViewModel { userId = userId, token = token } );
        }
        [HttpPost]
        public async Task<IActionResult> NewPassword(NewPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                NewPasswordViewDTO dTO = new NewPasswordViewDTO()
                {
                     UserId = model.userId, Token = model.token,
                     Password= model.Password,
                };

                if (await _appUserManager.UserPasswordReset(dTO))
                {
                    return RedirectToAction("LogIn");
                }
                
            }
            TempData["message"] = "Sifre S�f�rlanamad�";
                return View(model);
        }

        public IActionResult LogOut() //Todo: logout Hata var D�zeltilecek
        {
            _appUserManager.SignOutAsyncUser();
            return RedirectToAction("Index");
        }

    }

    
}
