using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SqlServer.Repository.Chrono
{
    public partial class ChronoRepository
    {
        public const string TableName = "chronos",
            ColId = "id",
            ColTimeInSeconds = "timeInSeconds";

        public static readonly string ReqCreate = $@"
        INSERT INTO {TableName}({ColTimeInSeconds})
        OUTPUT INSERTED.{ColId}
        VALUES(@{ColTimeInSeconds})";

        public static readonly string ReqGetAll = $@"
        SELECT * FROM {TableName}";

        public static readonly string ReqGetById = $@"
        SELECT * FROM {TableName}
        WHERE {ColId} = @{ColId}";

        public static readonly string ReqDelete = $@"
            DELETE FROM {TableName} WHERE {ColId} = @{ColId}";

        public static readonly string ReqUpdate = $@"
            UPDATE {TableName}
            SET {ColTimeInSeconds} = @{ColTimeInSeconds}
            WHERE {ColId} = @{ColId}";

    }
}
