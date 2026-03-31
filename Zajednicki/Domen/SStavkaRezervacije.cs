using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Zajednicki.Domen
{
    public class SStavkaRezervacije : IEntity
    {
        public int IdRezervacija { get; set; }
        public int RbStavka { get; set; }
        public int RbSStavka { get; set; }
        public string Registracija { get; set; }
        public double Cena { get; set; }
        public TipVozila TipVozila { get; set; }

        [JsonIgnore] public string TableName => "SStavkaRezervacije";
        [JsonIgnore]
        public string PrimaryKey =>
            $"idRezervacija = {IdRezervacija} AND rbStavka = {RbStavka} AND rbSStavka = {RbSStavka}";
        [JsonIgnore]
        public string Values =>
            $"{IdRezervacija}, {RbStavka}, {RbSStavka}, '{Registracija}', " +
            $"{Cena.ToString(System.Globalization.CultureInfo.InvariantCulture)}, " +
            $"{TipVozila.IdTipVozila}";
        [JsonIgnore]
        public string UpdateValues =>
            $"registracija = '{Registracija}', " +
            $"cena = {Cena.ToString(System.Globalization.CultureInfo.InvariantCulture)}, " +
            $"idTipVozila = {TipVozila.IdTipVozila}";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                SStavkaRezervacije ss = new SStavkaRezervacije
                {
                    IdRezervacija = (int)reader["idRezervacija"],
                    RbStavka = (int)reader["rbStavka"],
                    RbSStavka = (int)reader["rbSStavka"],
                    Registracija = (string)reader["registracija"],
                    Cena = Convert.ToDouble(reader["cena"]),
                    TipVozila = new TipVozila { IdTipVozila = (int)reader["idTipVozila"] }
                };
                lista.Add(ss);
            }
            return lista;
        }
    }
}
