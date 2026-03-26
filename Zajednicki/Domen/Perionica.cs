using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zajednicki.Domen
{
    public class Perionica : IEntity
    {
        public int IdPerionica { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string TablName => "Perionica";

        public string Values => $"'{Naziv}', '{Adresa}', '{Telefon}', '{Email}'";


        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                Perionica p = new Perionica
                {
                    IdPerionica = (int)reader["idPerionica"],
                    Naziv = (string)reader["naziv"],
                    Adresa = (string)reader["adresa"],
                    Telefon = (string)reader["telefon"],
                    Email = (string)reader["email"]
                };
                lista.Add(p);
            }
            return lista;
        }

        public override string ToString() => Naziv;
        public override bool Equals(object? obj) => obj is Perionica p && p.IdPerionica == IdPerionica;
        public override int GetHashCode() => IdPerionica.GetHashCode();
    }
}
