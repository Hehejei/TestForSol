using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestForSol.Models;
using TestForSol.Services;

namespace TestForSol.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrderService _orderService;

        private readonly IFilterService _filterService;

        public HomeController(IOrderService orderService, IFilterService filterService)
        {
            _orderService = orderService;
            _filterService = filterService;
        }

        public IActionResult Index(string[]? Number, int[]? ProviderId, DateTime? StartDate, DateTime? EndDate)
        {

            ViewBag.Orders = _orderService.GetOrders();

            ViewBag.OrderNumbers = _orderService.OrderNumbersList();
            ViewBag.Providers = _orderService.ProvidersList();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}