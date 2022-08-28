using System;
using System.Data.SqlClient;
namespace ADO.NET_Lab
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = 
                new SqlConnection(@"Server=DESKTOP-FVGCI9R\SQLEXPRESS; Database=Softuni; Integrated Security=true");
            sqlConnection.Open();
            string GetAllEmployeeNames = "SELECT [FirstName], [LastName] FROM [Employees]";
            SqlCommand cmd = new SqlCommand(GetAllEmployeeNames,sqlConnection);
            using SqlDataReader reader=cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"{reader["FirstName"]}, {reader["LastName"]}");
            }
            sqlConnection.Close();
            reader.Close();
        }
    }
}
