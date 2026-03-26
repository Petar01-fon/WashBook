using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zajednicki.Domen
{
    public class TipVozila : IEntity
    {
        public int IdTipVozila { get; set; }
        public string Naziv { get; set; }
        public string TablName => "TipVozila";
        public string Values => $"'{Naziv}'";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                TipVozila t = new TipVozila
                {
                    IdTipVozila = (int)reader["idTipVozila"],
                    Naziv = (string)reader["naziv"]
                };
                lista.Add(t);
            }
            return lista;
        }

        public override string ToString() => Naziv;
        public override bool Equals(object? obj) => obj is TipVozila t && t.IdTipVozila == IdTipVozila;
        public override int GetHashCode() => IdTipVozila.GetHashCode();
    }
}
