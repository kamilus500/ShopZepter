namespace ShopZepter.Domain.Entities
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<OrderShop> OrderShops { get; set; }
    }
}
