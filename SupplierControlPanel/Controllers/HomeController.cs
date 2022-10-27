using Microsoft.AspNetCore.Mvc;

namespace SupplierControlPanel.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Warehouse()
        {
            return View();
        }
    }
}
