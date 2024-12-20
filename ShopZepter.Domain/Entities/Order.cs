﻿using ShopZepter.Domain.Enums;

namespace ShopZepter.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public decimal Net { get; set; }
        public decimal Gross { get; set; }
        public int Count { get; set; }

        public PayType PayType { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public IEnumerable<OrderShop> OrderShops { get; set; }
    }
}