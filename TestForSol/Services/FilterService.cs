using Microsoft.IdentityModel.Tokens;
using TestForSol.Models;
using TestForSol.ViewModels;

namespace TestForSol.Services
{
    public interface IFilterService
    {
        public IEnumerable<OrderViewModel> Filter(FilterViewModel filter);
    }

    public class FilterService : IFilterService
    {
        private readonly DbCntx DbContext;

        public FilterService(DbCntx dbContext)
        {
            DbContext = dbContext;
        }

        public IEnumerable<OrderViewModel> Filter(FilterViewModel filter)
        {
            var orders = DbContext.Orders.Join(DbContext.Providers,
                o => o.ProviderId,
                p => p.Id,
                (o, p) => new OrderViewModel
                {
                    Id = o.Id,
                    Number = o.Number,
                    Date = o.Date,
                    ProviderName = p.Name
                }).ToList();

            if (filter.StartDate != null && filter.EndDate != null)
            {
               orders = orders.Where(o => o.Date >= filter.StartDate && o.Date <= filter.EndDate).ToList();    
            }

            if (!filter.Number.IsNullOrEmpty())
            {
                var result = new List<OrderViewModel>();

                for(int i = 0;  i < filter.Number.Length; i++)
                {
                    foreach (var order in orders)
                    {
                        if (order.Number == filter.Number[i])
                        {
                            result.Add(new OrderViewModel { Id = order.Id, Number = order.Number, Date = order.Date, ProviderName = order.ProviderName });
                        }
                    }
                }
                orders = result;
            }

            if (!filter.ProviderName.IsNullOrEmpty())
            {
                var result = new List<OrderViewModel>();

                for (int i = 0; i < filter.ProviderName.Length; i++)
                {
                    foreach (var order in orders)
                    {
                        if (order.ProviderName == filter.ProviderName[i])
                        {
                            result.Add(new OrderViewModel { Id = order.Id, Number = order.Number, Date = order.Date, ProviderName = order.ProviderName });
                        }
                    }
                }
                orders = result;
            }

            return orders; 
        }
    }
}
