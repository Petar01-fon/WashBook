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
            connection.RollBack();
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
            command.CommandText = $"select * from {entity.TableName}";
            using SqlDataReader reader = command.ExecuteReader();
            List<IEntity> list = entity.GetReaderList(reader);
            return list;
        }

        public void Add(IEntity entity)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"insert into {entity.TableName} values ({entity.Values})";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        public IEntity Prijavi(IEntity entity, string korisnickoIme, string sifra)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText =
                $"SELECT * FROM {entity.TableName} WHERE korisnickoIme = '{korisnickoIme}' AND sifra = '{sifra}'";
            using SqlDataReader reader = cmd.ExecuteReader();
            List<IEntity> lista = entity.GetReaderList(reader);
            if (lista.Count > 0)
                return lista[0];

            throw new Exception("Korisničko ime ili šifra nisu ispravni.");
        }

        public void Update(IEntity entity)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"update {entity.TableName} set {entity.UpdateValues} where {entity.PrimaryKey}";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        public void Delete(IEntity entity)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"delete from {entity.TableName} where {entity.PrimaryKey}";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        public IEntity GetById(IEntity entity)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"SELECT * FROM {entity.TableName} WHERE {entity.PrimaryKey}";
            using SqlDataReader reader = cmd.ExecuteReader();
            List<IEntity> lista = entity.GetReaderList(reader);
            if (lista.Count > 0)
                return lista[0];
            throw new Exception("Objekat nije pronađen.");
        }

        public Rezervacija GetRezervacija(int idRezervacija)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $@"
                                SELECT r.*, 
                                       ra.ime as imeRadnika, ra.prezime as prezimeRadnika, 
                                       k.ime as imeKorisnika, k.prezime as prezimeKorisnika
                                FROM Rezervacija r
                                JOIN Radnik ra ON r.idRadnik = ra.idRadnik
                                JOIN Korisnik k ON r.idKorisnik = k.idKorisnik
                                WHERE r.idRezervacija = {idRezervacija}";
            using SqlDataReader reader = cmd.ExecuteReader();
            List<IEntity> lista = new Rezervacija().GetReaderList(reader);
            if (lista.Count > 0)
                return (Rezervacija)lista[0];
            throw new Exception("Rezervacija nije pronađena.");
        }

        public List<IEntity> GetAllByCondition(IEntity entity, string condition)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"SELECT * FROM {entity.TableName} WHERE {condition}";
            using SqlDataReader reader = cmd.ExecuteReader();
            return entity.GetReaderList(reader);
        }
    }
}
