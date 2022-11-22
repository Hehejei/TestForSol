using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TestForSol.Models;

namespace TestForSol.Services
{
    public interface IOrderService
    {
        public IEnumerable<Order> GetOrders();
        public Order GetOrder(int id);
        public IEnumerable<Order> GetRecurringOrder(string number, int providerId);
        public IEnumerable<OrderItem> GetOrderItems(int id);
        public SelectList OrderNumbersList();
        public SelectList ProvidersList();
        public void CreateOrder(Order order);
        public void UpdateOrder(Order order);
        public void DeleteOrder(int id);
    }

    public class OrderService : IOrderService
    {

        private readonly DbCntx DbContext;

        public OrderService(DbCntx dbContext)
        {
            DbContext = dbContext;
        }
     
        public IEnumerable<Order> GetOrders()
            => DbContext.Orders;

        public Order GetOrder(int id) 
            => DbContext.Orders.FirstOrDefault(o => o.Id == id); 

        public IEnumerable<Order> GetRecurringOrder(string number, int providerId)
            => DbContext.Orders.Where(o => o.Number == number && o.ProviderId == providerId);

        public IEnumerable<OrderItem> GetOrderItems(int id) 
            => DbContext.OrderItems.AsNoTracking().Where(o => o.OrderId == id);
        public SelectList OrderNumbersList()
        {
            var Orders = DbContext.Orders.Select(o => o.Number).Distinct().Select(n => new { Number = n}).ToList();
            return new SelectList(Orders, "Number", "Number"); 
        }

        public SelectList ProvidersList()
            => new SelectList(DbContext.Providers, "Id", "Name");
        
        public void CreateOrder(Order order)
        {
            DbContext.Orders.Add(order);
            DbContext.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            DbContext.Orders.Update(order);
            DbContext.SaveChanges();
        }

        public void DeleteOrder(int id)
        {
            var orderItems = DbContext.OrderItems.Where(o => o.OrderId == id);
            DbContext.OrderItems.RemoveRange(orderItems);

            var order = DbContext.Orders.Where(o => o.Id == id);
            DbContext.Orders.RemoveRange(order);

            DbContext.SaveChanges();
        }
    }
}
