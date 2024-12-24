namespace ShopZepter.Domain.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }

        public IEnumerable<OrderClient> OrderClients { get; set; }
    }
}
