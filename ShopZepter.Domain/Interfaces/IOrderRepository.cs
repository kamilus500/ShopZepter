using ShopZepter.Domain.ViewModels;

namespace ShopZepter.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<OrderSummaryViewModel>> GetOrdersSummary(CancellationToken cancellationToken);
    }
}
