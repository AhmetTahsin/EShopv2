using EShop.BLL.DTOs.DTOClasesses;
using EShop.BLL.DTOs.DTOClasesses.EntitysDTO;
using EShop.BLL.ManagerServices.Abstracts;
using EShop.BLL.ManagerServices.Concretes;
using EShop.COREMVC.Models.PageModels.OrderModels;
using EShop.COREMVC.Models.PageModels.ShoppingModels;
using EShop.COREMVC.Models.SessionService;
using EShop.COREMVC.Models.ShoppingTools;
using EShop.ENTITIES.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using X.PagedList;

namespace EShop.COREMVC.Controllers
{
    
    public class ShoppingController : Controller
    {
        readonly IProductManager _productManager;
        readonly ICategoryManager _categoryManager;
        readonly IHttpClientFactory _httpClientFactory; //API Entegrasyonu için kullanıyoruz
        readonly IAppUserManager _appUserManager;
        public ShoppingController(IProductManager productManager, ICategoryManager categoryManager, IHttpClientFactory httpClientFactory, IAppUserManager appUserManager)
        {
            _productManager = productManager;
            _categoryManager = categoryManager;
            _httpClientFactory = httpClientFactory;
            _appUserManager = appUserManager;
        }



        public IActionResult Index(int? page, int? categoryID) 
        {

            ShoppingPageVM spVm = new ShoppingPageVM()
            {
                Products = categoryID == null ? _productManager.GetActives().ToPagedList(page ?? 1, 5) : _productManager.Where(x => x.CategoryID == categoryID).ToPagedList(page ?? 1, 5),
                //categoryID null ise aktif ürünleri listele sayfa numarası yok ise 1 yap 5 li listele
                //categoryID null degil ise seçili ise  .... listele
                Categories = _categoryManager.GetActives()

            };
            if (categoryID != null) TempData["catID"] = categoryID;

            return View(spVm);

        }
        #region Methods
        void ControlCart(Cart c)
        {
            if (c.GetCartItems.Count == 0) HttpContext.Session.Remove("scart");
        }
        Cart GetCartFromSession(string key)
        {
            return HttpContext.Session.GetObject<Cart>(key);
        }
        private void SetCart(Cart c)
        {
            HttpContext.Session.SetObject("scart", c);
        } 
        #endregion

        public async Task<IActionResult> AddToCart(int id)
        {
            Cart cart = GetCartFromSession("scart") == null ? new Cart() : GetCartFromSession("scart"); //null ise olustur 
            ProductDTO productToBeAdded = await _productManager.FindAsync(id);
            CartItem cirtItem = new()
            {
                ID = productToBeAdded.ID,
                ProductName = productToBeAdded.ProductName,
                UnitPrice = productToBeAdded.UnitPrice,
                ImagePath = productToBeAdded.ImagePath,
                CategoryName = productToBeAdded.Category.CategoryName,
                CategoryID = productToBeAdded.CategoryID
            };
            cart.AddToCart(cirtItem);

            SetCart(cart);

            TempData["message"] = $"{cirtItem.ProductName} isimli ürün sepete eklenmiştir";
            return RedirectToAction("Index");
        }


        public IActionResult CartPage()
        {
            if (GetCartFromSession("scart") == null)
            {
                TempData["message"] = "Sepetiniz su anda bos";
                return RedirectToAction("Index");
            }
            Cart c = HttpContext.Session.GetObject<Cart>("scart");
            return View(c);
        }

        public IActionResult DeleteFromCart(int id)
        {
            if (GetCartFromSession("scart") != null)
            {
                Cart c = GetCartFromSession("scart");
                c.RemoveFromCart(id);
                SetCart(c);

                ControlCart(c);

            }
            return RedirectToAction("CartPage");
        }

        public IActionResult DecreaseFromCart(int id)
        {
            if (GetCartFromSession("scart") != null)
            {
                Cart c = GetCartFromSession("scart");
                c.Decrease(id);
                SetCart(c);
                ControlCart(c);

            }
            return RedirectToAction("CartPage");
        }

        public IActionResult ConfirmOrder()
        {
            return View();
        }

    }
}
