using Microsoft.Data.SqlClient;
using One_City_One_Pay.Moduls;
using System.Data;

namespace One_City_One_Pay.Data
{
    public class RoutesRepository
    {
        private readonly string _connectionString;

        public RoutesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") 
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }

        public List<T> GetAllRoutes <T> (string storedProcedure) where T : BaseRoute, new()
        {
            List<T> routes = new List<T>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(storedProcedure, connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        routes.Add(new T
                        {
                            RouteId = Convert.ToInt32(reader["RouteId"]),
                            FromLocation = reader["FromLocation"]?.ToString() ?? string.Empty,
                            ToLocation = reader["ToLocation"]?.ToString() ?? string.Empty,
                            Price = Convert.ToDecimal(reader["Price"]),
                        });
                    }
                }
            }
            return routes;
        }

        public List<BikeRoute> GetAllBikeRoutes() => GetAllRoutes<BikeRoute>("GetAllBikeRoutes");
        public List<AutoRoute> GetAllAutoRoutes() => GetAllRoutes<AutoRoute>("GetAllAutoRoutes");
        public List<CarRoute> GetAllCarRoutes() => GetAllRoutes<CarRoute>("GetAllCarRoutes");
        public List<BusRoute> GetAllBusRoutes() => GetAllRoutes<BusRoute>("GetAllBusRoutes");
        public List<MetroRoute> GetAllMetroRoutes() => GetAllRoutes<MetroRoute>("GetAllMetroRoutes");
        public List<LocalTrainRoute> GetAllLocalTrainRoutes() => GetAllRoutes<LocalTrainRoute>("GetAllLocalTrainRoutes");
    }
}
