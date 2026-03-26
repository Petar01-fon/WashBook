using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zajednicki.Domen
{
    public class Korisnik : IEntity
    {
        public int IdKorisnik { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Adresa { get; set; }
        public Grad Grad { get; set; }
        public string ImePrezime => $"{Ime} {Prezime}";
        public string TablName => "Korisnik";
        public string Values =>
            $"'{Ime}', '{Prezime}', '{Telefon}', '{Email}', '{Adresa}', {Grad.idGrad}";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                Korisnik k = new Korisnik
                {
                    IdKorisnik = (int)reader["IdKorisnik"],
                    Ime = (string)reader["ime"],
                    Prezime = (string)reader["prezime"],
                    Telefon = (string)reader["telefon"],
                    Email = (string)reader["email"],
                    Adresa = (string)reader["adresa"],
                    Grad = new Grad { idGrad = (int)reader["idGrad"] }
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
