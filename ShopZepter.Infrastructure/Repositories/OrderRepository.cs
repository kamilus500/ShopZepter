using Microsoft.EntityFrameworkCore;
using ShopZepter.Domain.Interfaces;
using ShopZepter.Domain.ViewModels;
using ShopZepter.Infrastructure.Persistance;

namespace ShopZepter.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public OrderRepository(ApplicationDbContext dbContext)
            => _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public async Task<IEnumerable<OrderSummaryViewModel>> GetOrdersSummary(CancellationToken cancellationToken)
            => await _dbContext.Orders
                        .Where(o => (o.Gross * o.Count) >= 100)
                        .GroupBy(order => order.PayType)
                        .Select(o => new OrderSummaryViewModel()
                        {
                            Type = o.Key,
                            Count = o.Count(),
                            TotalGross = o.Sum(o => o.Gross)
                        }).ToListAsync(cancellationToken);
    }
}
