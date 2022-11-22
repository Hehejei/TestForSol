using TestForSol.Models;

namespace TestForSol.Services
{
    public interface IFilterService
    {
        //public IEnumerable<Order> GetOrder5(string[]? numbers);
        //public IEnumerable<Order> GetOrder4(string[]? numbers, DateTime StartDate, DateTime EndDate);
        //public IEnumerable<Order> GetOrder3(int[]? ProviderId, DateTime StartDate, DateTime EndDate);
        //public IEnumerable<Order> GetOrder2(string[]? numbers, int[]? ProviderId, DateTime? StartDate, DateTime? EndDate);
    }

    public class FilterService : IFilterService
    {
        private readonly DbCntx DbContext;
        public FilterService(DbCntx dbContext)
        {
            DbContext = dbContext;
        }

        //public IEnumerable<Order> GetOrder5(string?[] numbers)
        //{
        //    List<Order> orders = new List<Order>();

        //    foreach (var number in numbers)
        //    {
        //        var order = DbContext.Orders.FirstOrDefault(o => o.Number == number);
        //        if (order != null)
        //        {
        //            orders.Add(new Order { Id = order.Id, Number = order.Number, Date = order.Date, ProviderId = order.ProviderId });
        //        }
        //    }
        //    return orders;
        //}

        //public IEnumerable<Order> GetOrder4(string[]? numbers, DateTime StartDate, DateTime EndDate)
        //{
        //    List<Order> orders = new List<Order>();

        //    foreach (var number in numbers)
        //    {
        //        var order = DbContext.Orders.FirstOrDefault(o => o.Number == number && o.Date >= StartDate && o.Date <= EndDate);
        //        if (order != null)
        //        {
        //            orders.Add(new Order { Id = order.Id, Number = order.Number, Date = order.Date, ProviderId = order.ProviderId });
        //        }
        //    }
        //    return orders;
        //}

        //public IEnumerable<Order> GetOrder3(int[]? ProviderId, DateTime? StartDate, DateTime? EndDate)
        //{
        //    List<Order> orders = new List<Order>();

        //    foreach (var provider in ProviderId)
        //    {
        //        var order = DbContext.Orders.FirstOrDefault(o => o.ProviderId == provider && o.Date >= StartDate && o.Date <= EndDate);
        //        if (order != null)
        //        {
        //            orders.Add(new Order { Id = order.Id, Number = order.Number, Date = order.Date, ProviderId = order.ProviderId });
        //        }
        //    }
        //    return orders;
        //}

        //public IEnumerable<Order> GetOrder2(string[]? numbers, int[]? ProviderId, DateTime? StartDate, DateTime? EndDate)
        //{
        //    List<Order> orders = new List<Order>();

        //    foreach (var number in numbers)
        //    {
        //        foreach (var provider in ProviderId)
        //        { 
        //            var order = DbContext.Orders.Where(o => o.Number == number && o.ProviderId == provider && o.Date >= StartDate && o.Date <= EndDate);
        //            if (order != null)
        //            {
        //                orders.InsertRange(provider, order);
        //                    /*.Add(new Order { Id = order.Id, Number = order.Number, Date = order.Date, ProviderId = order.ProviderId });*/
        //            }
        //        }
                
        //    }
        //    return orders;
        //}
    }
}
