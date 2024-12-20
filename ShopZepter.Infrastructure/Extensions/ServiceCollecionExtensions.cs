using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopZepter.Domain.Interfaces;
using ShopZepter.Infrastructure.Persistance;
using ShopZepter.Infrastructure.Repositories;
using ShopZepter.Infrastructure.Seeders;
namespace ShopZepter.Infrastructure.Extensions
{
    public static class ServiceCollecionExtensions
    {
        public static void AddInfrastructureApi(this IServiceCollection services)
        {
            services.AddTransient<IOrderRepositorySql, OrderRepositorySql>();
        }

        public static void AddInfrastructureMvc(this IServiceCollection services)
        {
            services.AddTransient<IOrderRepository, OrderRepository>();
        }

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("connectionString") ?? throw new ArgumentNullException("Connection string is empty");

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
        }

        public static void AddSeeder(this IServiceCollection services)
        {
            services.AddScoped<Seeder>();
        }
    }
}
