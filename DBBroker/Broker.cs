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

        public IEntity GetRezervacija(int idRezervacija)
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
                return lista[0];
            throw new Exception("Rezervacija nije pronađena.");
        }

        public List<DateTime> GetZauzetiTermini(DateTime datum)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $@"
                SELECT termin FROM Rezervacija 
                WHERE CAST(termin AS DATE) = '{datum:yyyy-MM-dd}'
                AND statusRezervacije != 'STORNIRANA'";
            using SqlDataReader reader = cmd.ExecuteReader();
            List<DateTime> termini = new List<DateTime>();
            while (reader.Read())
                termini.Add((DateTime)reader["termin"]);
            return termini;
        }

        public List<IEntity> GetAllRezervacijeByCondition(string condition)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $@"
                        SELECT r.*,
                               ra.ime as imeRadnika, ra.prezime as prezimeRadnika,
                               k.ime as imeKorisnika, k.prezime as prezimeKorisnika,
                               u.naziv AS usluga,
                               tv.naziv AS tipVozila,
                               ss.registracija,
                               ss.cena
                        FROM Rezervacija r
                        JOIN Radnik ra ON r.idRadnik = ra.idRadnik
                        JOIN Korisnik k ON r.idKorisnik = k.idKorisnik
                        LEFT JOIN StavkaRezervacije st ON r.idRezervacija = st.idRezervacija
                        LEFT JOIN Usluga u ON u.idUsluga = st.idUsluga
                        LEFT JOIN TipVozila tv ON tv.idTipVozila = u.idTipVozila
                        LEFT JOIN SStavkaRezervacije ss ON ss.idRezervacija = st.idRezervacija
                                                       AND st.rbStavka = ss.rbStavka
                        WHERE {condition}";
            using SqlDataReader reader = cmd.ExecuteReader();
            return new Rezervacija().GetReaderList(reader);
        }

        public int GetLastInsertedId(string tableName, string idColumn)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"SELECT MAX({idColumn}) FROM {tableName}";
            return (int)cmd.ExecuteScalar();
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
