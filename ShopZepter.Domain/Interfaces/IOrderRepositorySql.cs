using ShopZepter.Domain.ViewModels;

namespace ShopZepter.Domain.Interfaces
{
    public interface IOrderRepositorySql
    {
        Task<IEnumerable<OrderViewModel>> GetOrderShops();
    }
}
