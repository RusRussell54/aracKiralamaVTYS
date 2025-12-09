using Npgsql;
using System;

namespace Car_Rental_Dbms_Project
{
    public static class DatabaseHelper
    {
        // Merkezileþtirilmiþ connection string
        public static string ConnectionString => 
            "Host=localhost;Port=5432;Database=CarDb;Username=postgres;Password=1234";

        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(ConnectionString);
        }

        /// <summary>
        /// PostgreSQL veritabanýný oluþturur (eðer yoksa)
        /// </summary>
        public static void EnsureDatabaseExists()
        {
            try
            {
                // Varsayýlan postgres veritabanýna baðlan
                string adminConnectionString = "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=1234";
                
                using (var connection = new NpgsqlConnection(adminConnectionString))
                {
                    connection.Open();
                    
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = @"
                            SELECT 1 FROM pg_database WHERE datname = 'CarDb'
                        ";
                        
                        var result = cmd.ExecuteScalar();
                        
                        if (result == null)
                        {
                            // Veritabaný yoksa oluþtur
                            using (var createCmd = connection.CreateCommand())
                            {
                                createCmd.CommandText = @"CREATE DATABASE ""CarDb"" ENCODING 'UTF8'";
                                createCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Veritabaný oluþturma hatasý: {ex.Message}", ex);
            }
        }
    }
}
