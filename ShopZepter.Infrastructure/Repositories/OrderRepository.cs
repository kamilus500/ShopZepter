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
                        .Include(o => o.Lines)
                        .Where(o => o.Lines.Sum(l => l.Gross * l.Count) >= 100)
                        .GroupBy(o => o.PayType)
                        .Select(o => new OrderSummaryViewModel()
                        {
                            Type = o.Key,
                            Count = o.Count(),
                            TotalGross = o.Sum(c => c.Lines.Sum(l => l.Gross * l.Count))
                        }).ToListAsync(cancellationToken);
    }
}
