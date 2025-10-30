using Microsoft.Data.SqlClient;
using One_City_One_Pay.Moduls;
using System.Data;

namespace One_City_One_Pay.Data
{
    public class BookingCountAndAmountRepository
    {
        private readonly string _connectionString;

        public BookingCountAndAmountRepository (IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }


        // Posting Booking Count And Amount Stored Procedure
        public void AddBikeBookingCountAndAmount(decimal bookingAmount, string VehicleType, string userName)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_BikeBookingCountAndAmount", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookingAmount", bookingAmount);
                cmd.Parameters.AddWithValue("@VehicleType", VehicleType);
                cmd.Parameters.AddWithValue("@UserName", userName);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void AddAutoBookingCountAndAmount(decimal bookingAmount, string VehicleType, string userName)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_AutoBookingCountAndAmount", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookingAmount", bookingAmount);
                cmd.Parameters.AddWithValue("@VehicleType", VehicleType);
                cmd.Parameters.AddWithValue("@UserName", userName);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void AddCarBookingCountAndAmount(decimal bookingAmount, string VehicleType, string userName)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_CarBookingCountAndAmount", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookingAmount", bookingAmount);
                cmd.Parameters.AddWithValue("@VehicleType", VehicleType);
                cmd.Parameters.AddWithValue("@UserName", userName);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void AddBusBookingCountAndAmount(decimal bookingAmount, string VehicleType, string userName)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_BusBookingCountAndAmount", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookingAmount", bookingAmount);
                cmd.Parameters.AddWithValue("@VehicleType", VehicleType);
                cmd.Parameters.AddWithValue("@UserName", userName);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void AddMetroBookingCountAndAmount(decimal bookingAmount, string VehicleType, string userName)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_MetroBookingCountAndAmount", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookingAmount", bookingAmount);
                cmd.Parameters.AddWithValue("@VehicleType", VehicleType);
                cmd.Parameters.AddWithValue("@UserName", userName);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void AddLocalTrainBookingCountAndAmount(decimal bookingAmount, string VehicleType, string userName)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_LocalTrainBookingCountAndAmount", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookingAmount", bookingAmount);
                cmd.Parameters.AddWithValue("@VehicleType", VehicleType);
                cmd.Parameters.AddWithValue("@UserName", userName);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }






        //Get all Booking count and amount List Without using SP = used inline for my ref
        public IEnumerable<BikeBookingCountAndAmount> GetBikeBookingCountAndAmount()
        {
            var bikeBookingData = new List<BikeBookingCountAndAmount>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT Id, BookingAmount, BookingDate,VehicleType,UserName FROM BikeBookingCountAndAmount", connection))
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bikeBookingData.Add(new BikeBookingCountAndAmount
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            BookingAmount = Convert.ToInt32(reader["BookingAmount"]),
                            BookingDate = Convert.ToDateTime(reader["BookingDate"]),
                            VehicleType = reader["VehicleType"].ToString(),
                            UserName = reader["UserName"].ToString()
                        });
                    }
                }
            }
            return bikeBookingData;
        }

        public IEnumerable<AutoBookingCountAndAmount> GetAutoBookingCountAndAmount()
        {
            var autoBookingData = new List<AutoBookingCountAndAmount>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT Id, BookingAmount, BookingDate,VehicleType,UserName FROM AutoBookingCountAndAmount", connection))
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        autoBookingData.Add(new AutoBookingCountAndAmount
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            BookingAmount = Convert.ToInt32(reader["BookingAmount"]),
                            BookingDate = Convert.ToDateTime(reader["BookingDate"]),
                            VehicleType = reader["VehicleType"].ToString(),
                            UserName = reader["UserName"].ToString()
                        });
                    }
                }
            }
            return autoBookingData;
        }

        public IEnumerable<CarBookingCountAndAmount> GetCarBookingCountAndAmount()
        {
            var carBookingData = new List<CarBookingCountAndAmount>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT Id, BookingAmount, BookingDate,VehicleType,UserName FROM CarBookingCountAndAmount", connection))
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        carBookingData.Add(new CarBookingCountAndAmount
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            BookingAmount = Convert.ToInt32(reader["BookingAmount"]),
                            BookingDate = Convert.ToDateTime(reader["BookingDate"]),
                            VehicleType = reader["VehicleType"].ToString(),
                            UserName = reader["UserName"].ToString()
                        });
                    }
                }
            }
            return carBookingData;
        }

        public IEnumerable<BusBookingCountAndAmount> GetBusBookingCountAndAmount()
        {
            var busBookingData = new List<BusBookingCountAndAmount>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT Id, BookingAmount, BookingDate,VehicleType,UserName FROM BusBookingCountAndAmount", connection))
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        busBookingData.Add(new BusBookingCountAndAmount
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            BookingAmount = Convert.ToInt32(reader["BookingAmount"]),
                            BookingDate = Convert.ToDateTime(reader["BookingDate"]),
                            VehicleType = reader["VehicleType"].ToString(),
                            UserName = reader["UserName"].ToString()
                        });
                    }
                }
            }
            return busBookingData;
        }

        public IEnumerable<MetroBookingCountAndAmount> GetMetroBookingCountAndAmount()
        {
            var metroBookingData = new List<MetroBookingCountAndAmount>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT Id, BookingAmount, BookingDate,VehicleType,UserName FROM MetroBookingCountAndAmount", connection))
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        metroBookingData.Add(new MetroBookingCountAndAmount
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            BookingAmount = Convert.ToInt32(reader["BookingAmount"]),
                            BookingDate = Convert.ToDateTime(reader["BookingDate"]),
                            VehicleType = reader["VehicleType"].ToString(),
                            UserName = reader["UserName"].ToString()
                        });
                    }
                }
            }
            return metroBookingData;
        }

        public IEnumerable<LocalTrainBookingCountAndAmount> GetLocalTrainBookingCountAndAmount()
        {
            var localTrainBookingData = new List<LocalTrainBookingCountAndAmount>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT Id, BookingAmount, BookingDate,VehicleType,UserName FROM LocalTrainBookingCountAndAmount", connection))
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        localTrainBookingData.Add(new LocalTrainBookingCountAndAmount
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            BookingAmount = Convert.ToInt32(reader["BookingAmount"]),
                            BookingDate = Convert.ToDateTime(reader["BookingDate"]),
                            VehicleType = reader["VehicleType"].ToString(),
                            UserName = reader["UserName"].ToString()
                        });
                    }
                }
            }
            return localTrainBookingData;
        }
    }
}
