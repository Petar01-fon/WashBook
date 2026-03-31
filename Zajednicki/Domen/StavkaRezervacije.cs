using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Zajednicki.Domen
{
    public class StavkaRezervacije : IEntity
    {
        public int IdRezervacija { get; set; }
        public int RbStavka { get; set; }
        public Usluga Usluga { get; set; }
        public List<SStavkaRezervacije> SStavke { get; set; } = new List<SStavkaRezervacije>();
        [JsonIgnore] public string TableName => "StavkaRezervacije";
        [JsonIgnore] public string PrimaryKey => $"idRezervacija = {IdRezervacija} AND rbStavka = {RbStavka}";
        [JsonIgnore] public string Values => $"{IdRezervacija}, {RbStavka}, {Usluga.IdUsluga}";
        [JsonIgnore] public string UpdateValues => $"idUsluga = {Usluga.IdUsluga}";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                StavkaRezervacije s = new StavkaRezervacije
                {
                    IdRezervacija = (int)reader["idRezervacija"],
                    RbStavka = (int)reader["rbStavka"],
                    Usluga = new Usluga { IdUsluga = (int)reader["idUsluga"] }
                };
                lista.Add(s);
            }
            return lista;
        }
    
    }
}
