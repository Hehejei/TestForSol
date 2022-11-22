using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TestForSol.Models;
using TestForSol.Services;

namespace TestForSol.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [Route("[action]/{Id}")]
        [Route("[controller]/[action]/{Id}")]
        public IActionResult AboutOrder(int id)
        {
            var order = _orderService.GetOrder(id);
            ViewBag.OrderItems = _orderService.GetOrderItems(id);
            return View(order);
        }

        public IActionResult CreateOrder()
        {
            ViewBag.Providers = _orderService.ProvidersList();
            return View();
        }
        [HttpPost]
        public IActionResult CreateOrder(Order order)
        {
            ViewBag.Providers = _orderService.ProvidersList();
            var Orders = _orderService.GetRecurringOrder(order.Number, order.ProviderId);

            if (ModelState.IsValid)
            {
                if (Orders.IsNullOrEmpty())
                {
                    _orderService.CreateOrder(order);
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("Number", "Number");
                ModelState.AddModelError("ProviderId", "ProviderId");

                return View(order);
            }

            return View(order);
        }

        public IActionResult UpdateOrder(int id)
        {

            ViewBag.Providers = _orderService.ProvidersList();

            var order = _orderService.GetOrder(id);
            return View(order);
        }
        [HttpPost]
        public IActionResult UpdateOrder(Order order)
        {
            ViewBag.Providers = _orderService.ProvidersList();

            var Orders = _orderService.GetRecurringOrder(order.Number, order.ProviderId);
            if (ModelState.IsValid)
            {
                if (Orders.IsNullOrEmpty())
                {
                    _orderService.UpdateOrder(order);
                   return RedirectToAction("AboutOrder", "Order", new { id = order.Id });
                }

                ModelState.AddModelError("Number", "Number");
                ModelState.AddModelError("ProviderId", "ProviderId");

                return View(order);
            }

            return View(order);
        }

        [Route("[controller]/[action]/{Id}")]
        public IActionResult DeleteOrder(int id)
        {
            _orderService.DeleteOrder(id);
            return RedirectToAction("Index","Home");
        }
    }
}
