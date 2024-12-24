using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ShopZepter.Domain.Interfaces;
using ShopZepter.Domain.ViewModels;
using System.Data;

namespace ShopZepter.Infrastructure.Repositories
{
    public class OrderRepositorySql : IOrderRepositorySql
    {
        private readonly string _connectionString;
        private IDbConnection Connection => new SqlConnection(_connectionString);

        public OrderRepositorySql(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("connectionString");
        }

        public async Task<IEnumerable<OrderViewModel>> GetOrderShops()
        {
            using (var dbConnection = Connection)
            {
                const string query = @"SELECT S.Name AS 'Name', O.Gross AS 'Gross', O.Net AS 'Net', O.Count AS 'Count', O.PayType AS 'Type', (O.Net * O.Count) AS SUM, C.City + ' ' + C.Street + ' ' + C.PostCode AS Adress
                                        FROM Orders O
                                        INNER JOIN OrderShops OS ON OS.OrderId = O.Id
										INNER JOIN OrderClients OC ON OC.OrderId = O.Id
                                        INNER JOIN Clients C ON C.Id = OC.ClientId
                                        INNER JOIN Shops S ON S.Id = OS.ShopId
                                        WHERE C.City LIKE '%w%'
                                        AND TRY_CAST(SUBSTRING(S.Name, CHARINDEX(' ', S.Name) + 1, LEN(S.Name)) AS INT) % 2 = 0;";

                return await dbConnection.QueryAsync<OrderViewModel>(query);
            }
        }
    }
}
