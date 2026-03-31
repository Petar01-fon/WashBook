using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Zajednicki.Domen
{
    public class Radnik : IEntity
    {
        public int IdRadnik { get; set; }
        public string KorisnickoIme { get; set; }
        public string Sifra { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Adresa { get; set; }
        public string Telefon { get; set; }
        [JsonIgnore] public string PrimaryKey => $"idRadnik = {IdRadnik}";
        [JsonIgnore]
        public string UpdateValues =>
                     $"korisnickoIme = '{KorisnickoIme}', sifra = '{Sifra}', ime = '{Ime}', " +
                     $"prezime = '{Prezime}', datumRodjenja = '{DatumRodjenja:yyyyMMdd}', " +
                     $"adresa = '{Adresa}', telefon = '{Telefon}'";
        [JsonIgnore] public string ImePrezime => $"{Ime} {Prezime}";
        [JsonIgnore] public string TableName => "Radnik";
        [JsonIgnore]
        public string Values =>
             $"'{KorisnickoIme}', '{Sifra}', '{Ime}', '{Prezime}', " +
             $"'{DatumRodjenja:yyyyMMdd}', '{Adresa}', '{Telefon}'";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();

            while (reader.Read())
            {
                Radnik r = new Radnik
                {
                    IdRadnik = (int)reader["IdRadnik"],
                    KorisnickoIme = (string)reader["korisnickoIme"],
                    Sifra = (string)reader["sifra"],
                    Ime = (string)reader["ime"],
                    Prezime = (string)reader["prezime"],
                    DatumRodjenja = (DateTime)reader["datumRodjenja"],
                    Adresa = (string)reader["adresa"],
                    Telefon = (string)reader["telefon"]
                };
                lista.Add(r);
            }
            return lista;
        }
        public override string ToString() => ImePrezime;
        public override bool Equals(object? obj) => obj is Radnik r && r.IdRadnik == IdRadnik;
        public override int GetHashCode() => IdRadnik.GetHashCode();


    }
}
