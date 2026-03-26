using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class PretraziTipVozilaSO : BaseSO
    {
        private TipVozila tipVozila;
        public TipVozila Result { get; set; }

        public PretraziTipVozilaSO(TipVozila tipVozila)
        {
            this.tipVozila = tipVozila;
        }

        protected override void ExecuteConcreteOperation()
        {
            Result = (TipVozila)broker.GetById(tipVozila);
        }
    }
}
