using Infrastructure.SqlServer.Utils;
using System.Data;
using System.Data.SqlClient;

namespace Infrastructure.SqlServer.Repository.Chrono
{
    public partial class ChronoRepository : IChronoRepository
    {
        private readonly IDomainFactory<Domain.Chrono> _factory = new ChronoFactory();
        public Domain.Chrono Create(Domain.Chrono chrono)
        {
            using var connection = Database.GetConnection();
            List<Domain.Chrono> users = GetAll();
            connection.Open();
            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = ReqCreate
            };
            command.Parameters.AddWithValue("@" +ColTimeInSeconds, chrono.TimeInSecond);
            chrono.Id = (int)command.ExecuteScalar();

            return chrono;
        }

        public bool Delete(Domain.Chrono chrono)
        {
            using var connection = Database.GetConnection();
            connection.Open();

            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = ReqDelete
            };
            command.Parameters.AddWithValue("@" + ColId, chrono.Id);
            return command.ExecuteNonQuery() > 0;
        }

        public List<Domain.Chrono> GetAll()
        {
            var chronos = new List<Domain.Chrono>();
            using var connection = Database.GetConnection();
            connection.Open();

            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = ReqGetAll
            };

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            while (reader.Read())
            {
                chronos.Add(_factory.CreateFromSqlReader(reader));
            }

            return chronos;
        }


        public bool Update(Domain.Chrono chrono)
        {
            using var connection = Database.GetConnection();
            connection.Open();

            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = ReqUpdate
            };

            command.Parameters.AddWithValue("@" + ColId, chrono.Id);
            command.Parameters.AddWithValue("@" + ColTimeInSeconds, chrono.TimeInSecond);
            return command.ExecuteNonQuery() > 0;
        }
    }
}
