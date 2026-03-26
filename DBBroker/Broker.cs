using Microsoft.Data.SqlClient;
using Zajednicki.Domen;

namespace DBBroker
{
    public class Broker
    {
        private DbConnection connection;

        public Broker()
        {
            connection = new DbConnection();
        }

        public void Rollback()
        {
            connection.RallBack();
        }

        public void Commit()
        {
            connection.Commit();
        }

        public void BeginTransaction()
        {
            connection.BeginTransaction();
        }
        public void CloseConnection()
        {
            connection.CloseConnection();
        }

        public void OpenConnection()
        {
            connection.OpenConnection();
        }

        public List<IEntity> GetAll(IEntity entity)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"select * from {entity.TablName}";
            using SqlDataReader reader = command.ExecuteReader() ;
            List<IEntity> list = entity.GetReaderList(reader) ;
            return list ;
        }

        public void Add(IEntity entity)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"insert into {entity.TablName} values ({entity.Values})";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }
    }
}
