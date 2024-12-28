namespace ShopZepter.Domain.Entities
{
    public class OrderLine
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public decimal Net { get; set; }
        public decimal Gross { get; set; }
        public int Count { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
