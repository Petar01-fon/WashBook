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
        public List<StavkaRezervacije> Stavke { get; set; } = new List<StavkaRezervacije>();

        public string PrimaryKey => $"idRezervacija = {IdRezervacija}";
        public string UpdateValues =>
            $"datumRezervacije = '{DatumRezervacije:yyyy-MM-dd}', " +
            $"terminPreuzimanja = '{TerminPreuzimanja:yyyy-MM-dd HH:mm:ss}', " +
            $"terminVracanja = '{TerminVracanja:yyyy-MM-dd HH:mm:ss}', " +
            $"statusRezervacije = '{StatusRezervacije}', " +
            $"idRadnik = {Radnik.IdRadnik}, idKorisnik = {Korisnik.IdKorisnik}";
        public string TableName => "Rezervacija";

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
                    Radnik = new Radnik 
                    { 
                        IdRadnik = (int)reader["idRadnika"],
                        Ime = (string)reader["imeRadnika"],
                        Prezime = (string)reader["prezimeRadnika"]
                    },
                    Korisnik = new Korisnik 
                    { 
                        IdKorisnik = (int)reader["idKorisnik"],
                        Ime = (string)reader["imeKorisnika"],
                        Prezime = (string)reader["prezimeKorisnika"]
                    }
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

