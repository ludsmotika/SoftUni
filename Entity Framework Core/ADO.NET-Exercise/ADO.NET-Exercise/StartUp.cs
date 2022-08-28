using System;
using System.Data;
using System.Data.SqlClient;

namespace ADO.NET_Exercise
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            SqlConnection connection = new SqlConnection(Config.ConfigPath);
            connection.Open();

            string cmdText = @"SELECT [Name], COUNT(mv.MinionId) AS [MinionsCount] FROM [Villains] AS [v] 
                                 JOIN [MinionsVillains] AS[mv] ON v.Id = mv.VillainId
                             GROUP BY v.[Name]
                               HAVING COUNT(mv.MinionId)>3 
                             ORDER BY COUNT(mv.MinionId) DESC";

            SqlCommand cmd = new SqlCommand(cmdText, connection);
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader["Name"]} - {reader["MinionsCount"]}");
            }
            connection.Close();

        }
    }
}
