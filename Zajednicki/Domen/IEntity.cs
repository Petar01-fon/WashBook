using Microsoft.Data.SqlClient;

namespace Zajednicki.Domen
{
    public interface IEntity
    {
        string TablName { get; }

        string Values { get; }

        List<IEntity> GetReaderList(SqlDataReader reader);
    }
}
