using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.RentACarFiltersComponents
{
    public class RentACarFilterComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string v)
        {
            v = "sa";
            TempData["value"] = v;
            return View();
        }
    }
}
