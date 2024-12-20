using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopZepter.Domain.Interfaces;
using ShopZepter.Domain.ViewModels;
using ShopZepter.MVC.Models;
using System.Diagnostics;

namespace ShopZepter.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IOrderRepository _orderRepository;

        public HomeController(HttpClient httpClient, IOrderRepository orderRepository)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> EfCore(CancellationToken cancellationToken)
            => View(await _orderRepository.GetOrdersSummary(cancellationToken));

        public async Task<IActionResult> RestApi()
        {
            using (var httpClient = new HttpClient())
            {
                var url = "https://localhost:7111/Orders";

                var response = await httpClient.GetAsync(url);

                string responseBody = await response.Content.ReadAsStringAsync();

                var orders = JsonConvert.DeserializeObject<IEnumerable<OrderViewModel>>(responseBody);

                return View(orders);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
