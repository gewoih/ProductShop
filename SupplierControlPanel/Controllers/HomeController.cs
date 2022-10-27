using Microsoft.AspNetCore.Mvc;
using SupplierControlPanel.Services;

namespace SupplierControlPanel.Controllers
{
    public class HomeController : Controller
    {
        private readonly WarehouseService warehouseService;

        public HomeController(WarehouseService warehouseService)
        {
            this.warehouseService = warehouseService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Warehouse()
        {
            return View(warehouseService.EndingProducts);
        }
    }
}
