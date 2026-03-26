using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class UbaciTipVozilaSO : BaseSO
    {

        private TipVozila tipVozila;

        public UbaciTipVozilaSO(TipVozila tipVozila)
        {
            this.tipVozila = tipVozila;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Add(tipVozila);
        }
    }
}
