using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Zajednicki.Domen
{
    public class Korisnik : IEntity
    {
        public int IdKorisnik { get; set; }
        public string KorisnickoIme { get; set; }
        public string Sifra { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Adresa { get; set; }
        public Grad Grad { get; set; }
        [JsonIgnore] public string PrimaryKey => $"idKorisnik = {IdKorisnik}";
       [JsonIgnore] public string UpdateValues =>
            $"korisnickoIme = '{KorisnickoIme}', sifra = '{Sifra}', ime = '{Ime}', " +
            $"prezime = '{Prezime}', telefon = '{Telefon}', email = '{Email}', " +
            $"adresa = '{Adresa}', idGrad = {Grad.IdGrad}";
        [JsonIgnore] public string ImePrezime => $"{Ime} {Prezime}";
        [JsonIgnore] public string TableName => "Korisnik";
       [JsonIgnore] public string Values =>
            $"'{KorisnickoIme}', '{Sifra}','{Ime}', '{Prezime}', '{Telefon}', '{Email}', '{Adresa}', {Grad.IdGrad}";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                Korisnik k = new Korisnik
                {
                    IdKorisnik = (int)reader["IdKorisnik"],
                    KorisnickoIme = (string)reader["korisnickoIme"],
                    Sifra = (string)reader["sifra"],
                    Ime = (string)reader["ime"],
                    Prezime = (string)reader["prezime"],
                    Telefon = (string)reader["telefon"],
                    Email = (string)reader["email"],
                    Adresa = (string)reader["adresa"],
                    Grad = new Grad { IdGrad = (int)reader["idGrad"] }
                };
                lista.Add(k);
            }
            return lista;
        }
        public override string ToString() => ImePrezime;
        public override bool Equals(object? obj) => obj is Korisnik k && k.IdKorisnik == IdKorisnik;
        public override int GetHashCode() => IdKorisnik.GetHashCode();

    }
}
