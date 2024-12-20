using Microsoft.AspNetCore.Mvc;
using ShopZepter.Domain.Interfaces;

namespace ShopZepter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepositorySql _orderRepositorySql;
        public OrdersController(IOrderRepositorySql orderRepositorySql)
            => _orderRepositorySql = orderRepositorySql ?? throw new ArgumentNullException(nameof(orderRepositorySql));

        [HttpGet("/Orders")]
        public async Task<IActionResult> GetOrders()
            => Ok(await _orderRepositorySql.GetOrderShops());
    }
}
