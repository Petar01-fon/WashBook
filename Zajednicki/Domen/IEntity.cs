using Microsoft.Data.SqlClient;

namespace Zajednicki.Domen
{
    public interface IEntity
    {
        string TableName { get; }

        string Values { get; }

        string PrimaryKey { get;}

        string UpdateValues { get; }

        List<IEntity> GetReaderList(SqlDataReader reader);
    }
}
