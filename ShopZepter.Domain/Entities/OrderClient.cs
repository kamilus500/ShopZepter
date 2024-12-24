namespace ShopZepter.Domain.Entities
{
    public class OrderClient
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
