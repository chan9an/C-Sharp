using Microsoft.Data.SqlClient;
using FlightSearchEngine.Models;

namespace FlightSearchEngine.Data
{
    public class DatabaseHelper
    {
        private readonly string _connectionString;

        public DatabaseHelper(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<string>> GetSourcesAsync()
        {
            var sources = new List<string>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("sp_GetSources", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    await connection.OpenAsync();
                    var reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        sources.Add(reader["Source"].ToString());
                    }
                }
            }

            return sources;
        }

        public async Task<List<string>> GetDestinationsAsync()
        {
            var destinations = new List<string>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("sp_GetDestinations", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    await connection.OpenAsync();
                    var reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        destinations.Add(reader["Destination"].ToString());
                    }
                }
            }

            return destinations;
        }

        public async Task<List<FlightResult>> SearchFlightsAsync(string source, string destination, int persons)
        {
            var results = new List<FlightResult>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("sp_SearchFlights", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Source", source);
                    command.Parameters.AddWithValue("@Destination", destination);
                    command.Parameters.AddWithValue("@Persons", persons);

                    await connection.OpenAsync();
                    var reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        var flight = new FlightResult
                        {
                            FlightId    = Convert.ToInt32(reader["FlightId"]),
                            FlightName  = reader["FlightName"].ToString(),
                            FlightType  = reader["FlightType"].ToString(),
                            Source      = reader["Source"].ToString(),
                            Destination = reader["Destination"].ToString(),
                            TotalCost   = Convert.ToDecimal(reader["TotalCost"])
                        };
                        results.Add(flight);
                    }
                }
            }

            return results;
        }

        public async Task<List<FlightHotelResult>> SearchFlightsWithHotelsAsync(string source, string destination, int persons)
        {
            var results = new List<FlightHotelResult>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("sp_SearchFlightsWithHotels", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Source", source);
                    command.Parameters.AddWithValue("@Destination", destination);
                    command.Parameters.AddWithValue("@Persons", persons);

                    await connection.OpenAsync();
                    var reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        var item = new FlightHotelResult
                        {
                            FlightId    = Convert.ToInt32(reader["FlightId"]),
                            FlightName  = reader["FlightName"].ToString(),
                            Source      = reader["Source"].ToString(),
                            Destination = reader["Destination"].ToString(),
                            HotelName   = reader["HotelName"].ToString(),
                            TotalCost   = Convert.ToDecimal(reader["TotalCost"])
                        };
                        results.Add(item);
                    }
                }
            }

            return results;
        }
    }
}
