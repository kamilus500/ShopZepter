namespace ShopZepter.Domain.Entities
{
    public class OrderShop
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ShopId { get; set; }
        public Shop Shop { get; set; }
    }
}
