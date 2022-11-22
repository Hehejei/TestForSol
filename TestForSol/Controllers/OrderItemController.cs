using Microsoft.AspNetCore.Mvc;
using TestForSol.Models;
using TestForSol.Services;

namespace TestForSol.Controllers
{
    public class OrderItemController : Controller
    {
        private readonly IOrderItemService _orderItemService;

        private readonly IOrderService _orderService;

        public OrderItemController( IOrderItemService orderItemService, IOrderService orderService)
        {
            _orderItemService = orderItemService;
            _orderService = orderService;
        }

        public IActionResult CreateOrderItem(int OrderId)
        {
            ViewBag.OrderId = OrderId;
            return View();
        }
        [HttpPost]
        public IActionResult CreateOrderItem(OrderItem orderItem)
        {
            ViewBag.OrderId = orderItem.OrderId;
            var order = _orderService.GetOrder(orderItem.OrderId);

            if (ModelState.IsValid)
            {
                if (order.Number == orderItem.Name)
                {
                    ModelState.AddModelError("Name", "Неверно");
                    return View(orderItem);
                }
                _orderItemService.CreateOrderItem(orderItem);
                return RedirectToAction("AboutOrder", "Order", new { id = orderItem.OrderId });
            }
            return View(orderItem);
        }

        public IActionResult DeleteOrderItem(int id, int orderId)
        {
            _orderItemService.DeleteOrderItem(id);
            return RedirectToAction("AboutOrder", "Order", new { id = orderId });
        }
    }
}
