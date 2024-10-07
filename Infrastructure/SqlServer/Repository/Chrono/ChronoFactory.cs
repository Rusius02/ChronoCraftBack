using Infrastructure.SqlServer.Repository.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repository.Chrono
{
    public class ChronoFactory : IDomainFactory<Domain.Chrono>
    {
        public Domain.Chrono CreateFromSqlReader(SqlDataReader reader)
        {

            return new Domain.Chrono()
            {
                Id = reader.GetInt32(reader.GetOrdinal(ChronoRepository.ColId)),
                TimeInSecond = reader.GetDouble(reader.GetOrdinal(ChronoRepository.ColTimeInSeconds))
            };
        }
    }
}
