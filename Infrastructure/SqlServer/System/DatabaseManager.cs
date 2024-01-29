using System.Data.SqlClient;
using System.IO;

namespace Infrastructure.SqlServer.System
{
    public class DatabaseManager : IDatabaseManager
    {
        public void CreateAndFillDatabaseAndTables()
        {
            ReadAndExecuteFile(
                @"C:\Users\Adrien\RiderProjects\ExamenASPSTIEVENARTAdrien\Infrastructure\SqlServer\Ressources\setup.sql");

        }

        private static void ReadAndExecuteFile(string filePath)
        {
            var script = File.ReadAllText(filePath);

            var connection = Database.GetConnection();
            connection.Open();
            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = script
            };

            command.ExecuteNonQuery();
        }

    }
}