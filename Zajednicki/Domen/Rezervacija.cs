using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zajednicki.Domen
{
    public class Rezervacija : IEntity
    {
        public int IdRezervacija { get; set; }
        public DateTime DatumRezervacije { get; set; }
        public DateTime TerminPreuzimanja { get; set; }
        public DateTime TerminVracanja { get; set; }
        public StatusRezervacije StatusRezervacije { get; set; } = StatusRezervacije.KREIRANA;
        public Radnik Radnik { get; set; }
        public Korisnik Korisnik { get; set; }
        public string TablName => "Rezervacija";

        public string Values => $"'{DatumRezervacije:yyyy-MM-dd}', " +
                                $"'{TerminPreuzimanja:yyyy-MM-dd HH:mm:ss}', " +
                                $"'{TerminVracanja:yyyy-MM-dd HH:mm:ss}', " +
                                $"'{StatusRezervacije}', " +
                                $"{Radnik.IdRadnik}, {Korisnik.IdKorisnik}";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {

            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                Rezervacija r = new Rezervacija
                {
                    IdRezervacija = (int)reader["idRezervacija"],
                    DatumRezervacije = (DateTime)reader["datumRezervacije"],
                    TerminPreuzimanja = (DateTime)reader["terminPreuzimanja"],
                    TerminVracanja = (DateTime)reader["terminVracanja"],
                    StatusRezervacije = Enum.Parse<StatusRezervacije>((string)reader["statusRezervacije"]),
                    Radnik = new Radnik { IdRadnik = (int)reader["idRadnik"] },
                    Korisnik = new Korisnik { IdKorisnik = (int)reader["idKorisnik"] }
                };
                lista.Add(r);
            }
            return lista;
        }

        public override string ToString() => $"Rez. #{IdRezervacija} – {DatumRezervacije:dd.MM.yyyy} [{StatusRezervacije}]";
        public override bool Equals(object? obj) => obj is Rezervacija r && r.IdRezervacija == IdRezervacija;
        public override int GetHashCode() => IdRezervacija.GetHashCode();
    }
}
}
