using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using TestForSol.Models;
using TestForSol.Services;
using TestForSol.ViewModels;

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

        public IActionResult Index(FilterViewModel? filter)
        {
            if (filter.StartDate != null || filter.EndDate != null || !filter.Number.IsNullOrEmpty() || !filter.ProviderName.IsNullOrEmpty())
            {
                ViewBag.Orders = _filterService.Filter(filter);
            }
            else
            {
                ViewBag.Orders = _orderService.GetOrders();
            }

            ViewBag.OrderNumbers = _orderService.OrderNumbersList();
            ViewBag.Providers = _orderService.ProvidersListName();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}