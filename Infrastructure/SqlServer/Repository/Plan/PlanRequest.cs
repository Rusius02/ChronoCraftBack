using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SqlServer.Repository.Plan
{
    public partial class PlanRepository
    {
        public const string TableName = "plans",
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
