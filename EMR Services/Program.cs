using System;
using System.Threading.Tasks;
using Npgsql;

namespace TotalNumberOfHtsClients
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string connectionString = "Host=localhost;Username=postgres;Password=lamis;Database=lamisplus";
            string query = "SELECT COUNT(*) FROM hts_client";  

            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        // Execute the query and get the count result
                        var result = await cmd.ExecuteScalarAsync();
                        Console.WriteLine($"Total number  of 'hts client tested is  ': {result}");
                    }
                }
            }
            catch (Exception uncle)
            {
                Console.WriteLine($"Error: {uncle.Message}");
            }
        }
    }
}
