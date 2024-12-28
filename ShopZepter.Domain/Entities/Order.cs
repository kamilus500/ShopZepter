using ShopZepter.Domain.Enums;

namespace ShopZepter.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public PayType PayType { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public IEnumerable<OrderLine> Lines { get; set; }
        public IEnumerable<OrderShop> OrderShops { get; set; }
    }
}
