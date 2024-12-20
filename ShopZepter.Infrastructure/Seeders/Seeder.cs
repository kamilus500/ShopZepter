using Microsoft.EntityFrameworkCore;
using ShopZepter.Domain.Entities;
using ShopZepter.Infrastructure.Persistance;

namespace ShopZepter.Infrastructure.Seeders
{
    public class Seeder
    {
        private readonly ApplicationDbContext _dbContext;
        public Seeder(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Clients.Any())
                {
                    var clients = new List<Client>() {
                        new Client()
                        {
                            Street = "Kielecka",
                            City = "Konin",
                            PostCode = "42-240"
                        },
                        new Client()
                        {
                            Street = "Nowakowska",
                            City = "Warszawa",
                            PostCode = "42-240"
                        },
                        new Client()
                        {
                            Street = "Kochanowska",
                            City = "Wrzosowa",
                            PostCode = "42-240"
                        }
                    };

                    _dbContext.Clients.AddRange(clients);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Shops.Any())
                {
                    var shops = new List<Shop>()
                    {
                        new Shop()
                        {
                            Name = "Sklep 1"
                        },
                        new Shop()
                        {
                            Name = "Sklep 2"
                        },
                        new Shop()
                        {
                            Name = "Sklep 3"
                        },
                        new Shop()
                        {
                            Name = "Sklep 4"
                        },
                        new Shop()
                        {
                            Name = "Sklep 5"
                        },
                        new Shop()
                        {
                            Name = "Sklep 6"
                        },
                        new Shop()
                        {
                            Name = "Sklep 7"
                        },
                        new Shop()
                        {
                            Name = "Sklep 8"
                        },
                        new Shop()
                        {
                            Name = "Sklep 9"
                        },
                        new Shop()
                        {
                            Name = "Sklep 10"
                        },
                    };

                    _dbContext.Shops.AddRange(shops);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Orders.Any())
                {
                    var orders = new List<Order>()
                    {
                        new Order()
                        {
                            ClientId = 1,
                            Code = 42125,
                            Count = 2,
                            Gross = (decimal)25.0,
                            Net = (decimal)15.0,
                            PayType = Domain.Enums.PayType.Card
                        },
                        new Order()
                        {
                            ClientId = 2,
                            Code = 33221,
                            Count = 2,
                            Gross = (decimal)5.0,
                            Net = (decimal)2.5,
                            PayType = Domain.Enums.PayType.Transfer
                        },
                        new Order()
                        {
                            ClientId = 3,
                            Code = 133768,
                            Count = 31,
                            Gross = (decimal)95.00,
                            Net = (decimal)65.00,
                            PayType = Domain.Enums.PayType.Cash
                        }
                    };

                    _dbContext.Orders.AddRange(orders);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.OrderShops.Any())
                {
                    var orderShops = new List<OrderShop>()
                    {
                        new OrderShop()
                        {
                            ShopId = 1,
                            OrderId = 1,
                        },
                        new OrderShop()
                        {
                            ShopId = 2,
                            OrderId = 2
                        },
                        new OrderShop()
                        {
                            ShopId = 3,
                            OrderId = 3
                        },
                    };

                    _dbContext.OrderShops.AddRange(orderShops);
                    _dbContext.SaveChanges();
                }
            }
        }
    }
}
