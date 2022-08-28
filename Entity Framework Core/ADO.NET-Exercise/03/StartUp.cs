using System;
using System.Data.SqlClient;

namespace _03
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(Config.ConfigPath);
            connection.Open();
            int id = int.Parse(Console.ReadLine());

            string villain = @"SELECT [Name] 
                                 FROM [Villains] 
                                WHERE Id = @id";

            SqlCommand villainCmd = new SqlCommand(villain, connection);
            villainCmd.Parameters.AddWithValue("@id", id);
            string villainName = (string)villainCmd.ExecuteScalar();
            if (villainName == null)
            {
                Console.WriteLine($"No villain with ID {id} exists in the database.");
                return;
            }
            else
            {
                Console.WriteLine($"Villain: {villain}");
            }




            connection.Close();

        }
    }
}
