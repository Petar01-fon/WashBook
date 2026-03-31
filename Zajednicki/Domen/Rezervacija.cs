using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Zajednicki.Domen
{
    public class Rezervacija : IEntity
    {
        public int IdRezervacija { get; set; }
        public DateTime DatumRezervacije { get; set; }
        public DateTime Termin{ get; set; }
        public StatusRezervacije StatusRezervacije { get; set; } = StatusRezervacije.KREIRANA;
        public Radnik Radnik { get; set; }
        public Korisnik Korisnik { get; set; }
        public List<StavkaRezervacije> Stavke { get; set; } = new List<StavkaRezervacije>();
        public string NazivUsluge { get; set; }
        public string NazivTipVozila { get; set; }
        public string Registracija { get; set; }
        public double Cena { get; set; }

        [JsonIgnore] public string ImeRadnika => $"{Radnik?.Ime} {Radnik?.Prezime}".Trim();
        [JsonIgnore] public string ImeKorisnika => $"{Korisnik?.Ime} {Korisnik?.Prezime}".Trim();
        [JsonIgnore] public string PrimaryKey => $"idRezervacija = {IdRezervacija}";
        [JsonIgnore]
        public string UpdateValues =>
            $"datumRezervacije = '{DatumRezervacije:yyyy-MM-dd}', " +
            $"termin = '{Termin:yyyy-MM-dd HH:mm:ss}', " +
            $"statusRezervacije = '{StatusRezervacije}', " +
            $"idRadnik = {Radnik.IdRadnik}, idKorisnik = {Korisnik.IdKorisnik}";
        [JsonIgnore] public string TableName => "Rezervacija";

        [JsonIgnore]
        public string Values =>
            $"'{DatumRezervacije:yyyy-MM-dd}', " +
            $"'{Termin:yyyy-MM-dd HH:mm:ss}', " +
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
                    Termin = (DateTime)reader["termin"],
                    StatusRezervacije = Enum.Parse<StatusRezervacije>((string)reader["statusRezervacije"].ToString().Trim()),
                    Radnik = new Radnik
                    {
                        IdRadnik = (int)reader["idRadnik"],
                        Ime = ReaderHasColumn(reader, "imeRadnika") ? (string)reader["imeRadnika"] : "",
                        Prezime = ReaderHasColumn(reader, "prezimeRadnika") ? (string)reader["prezimeRadnika"] : ""
                    },
                    Korisnik = new Korisnik
                    {
                        IdKorisnik = (int)reader["idKorisnik"],
                        Ime = ReaderHasColumn(reader, "imeKorisnika") ? (string)reader["imeKorisnika"] : "",
                        Prezime = ReaderHasColumn(reader, "prezimeKorisnika") ? (string)reader["prezimeKorisnika"] : ""
                    },
                    NazivTipVozila = ReaderHasColumn(reader, "tipVozila") && reader["tipVozila"] != DBNull.Value ? (string)reader["tipVozila"] : "",
                    NazivUsluge = ReaderHasColumn(reader, "usluga") && reader["usluga"] != DBNull.Value ? (string)reader["usluga"] : "",
                    Registracija = ReaderHasColumn(reader, "registracija") && reader["registracija"] != DBNull.Value ? (string)reader["registracija"] : "",
                    Cena = ReaderHasColumn(reader, "cena") && reader["cena"] != DBNull.Value ? Convert.ToDouble(reader["cena"]) : 0
                };
                lista.Add(r);
            }
            return lista;
        }

        private bool ReaderHasColumn(SqlDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
                if (reader.GetName(i) == columnName) return true;
            return false;
        }

        public override string ToString() => $"Rez. #{IdRezervacija} – {Termin:dd.MM.yyyy HH:mm} [{StatusRezervacije}]";
        public override bool Equals(object? obj) => obj is Rezervacija r && r.IdRezervacija == IdRezervacija;
        public override int GetHashCode() => IdRezervacija.GetHashCode();
    }
}

