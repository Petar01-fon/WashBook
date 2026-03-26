using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class ObrisiTipVozilaSO : BaseSO
    {
        private TipVozila tipVozila;

        public ObrisiTipVozilaSO(TipVozila tipVozila)
        {
            this.tipVozila = tipVozila;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Delete(tipVozila);   
        }
    }
}
