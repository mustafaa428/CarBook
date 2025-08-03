using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title1 = "Ana sayfa";
            ViewBag.Title2 = "Hizmetler";
            ViewBag.Title3 = "Hizmetlerimiz";
            return View();
        }
    }
}
