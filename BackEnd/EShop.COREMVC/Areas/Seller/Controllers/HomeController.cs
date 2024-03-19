using Microsoft.AspNetCore.Mvc;

namespace EShop.COREMVC.Areas.Seller.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
