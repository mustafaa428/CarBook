using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title1 = "Ana sayfa";
            ViewBag.Title2 = "Hakkımızda";
            ViewBag.Title3 = "Vizyonumuz & Misyonumuz";
            return View();
        }
    }
}
