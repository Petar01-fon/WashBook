using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Zajednicki.Domen
{
    public class Usluga : IEntity
    {
        public int IdUsluga { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public double Cena { get; set; }
        public TipVozila TipVozila { get; set; }
        [JsonIgnore] public string PrimaryKey => $"idUsluga = {IdUsluga}";
        [JsonIgnore] public string UpdateValues => $"naziv = '{Naziv}', opis = '{Opis}'";
        [JsonIgnore] public string TableName => "Usluga";
        [JsonIgnore] public string Values => $"'{Naziv}', '{Opis}'";


        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                Usluga u = new Usluga
                {
                    IdUsluga = (int)reader["idUsluga"],
                    Naziv = (string)reader["naziv"],
                    //Opis = reader["opis"] == DBNull.Value ? "" : (string)reader["opis"],
                    Cena = Convert.ToDouble(reader["cena"]),
                    TipVozila = new TipVozila { IdTipVozila = (int)reader["idTipVozila"] }
                };
                lista.Add(u);
            }
            return lista;
        }

        public override string ToString() => Naziv;
        public override bool Equals(object? obj) => obj is Usluga u && u.IdUsluga == IdUsluga;
        public override int GetHashCode() => IdUsluga.GetHashCode();
    }
}
