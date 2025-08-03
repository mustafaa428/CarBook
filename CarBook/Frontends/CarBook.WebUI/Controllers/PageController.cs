using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class PageController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
