using TestForSol.Models;

namespace TestForSol.Services
{
    public interface IOrderItemService
    {
        public void CreateOrderItem(OrderItem orderItem);
        public void DeleteOrderItem(int id);
    }

    public class OrderItemService : IOrderItemService
    {
        private readonly DbCntx DbContext;

        public OrderItemService(DbCntx dbContext)
        {
            DbContext = dbContext;
        }

        public void CreateOrderItem(OrderItem orderItem)
        {
            DbContext.OrderItems.Add(orderItem);
            DbContext.SaveChanges();
        }

        public void DeleteOrderItem(int id)
        {
            DbContext.OrderItems.Remove(new OrderItem { Id = id });
            DbContext.SaveChanges();
        }
    }
}
