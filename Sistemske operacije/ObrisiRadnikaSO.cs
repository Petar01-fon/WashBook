using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class ObrisiRadnikaSO : BaseSO
    {
        private Radnik radnik;

        public ObrisiRadnikaSO(Radnik radnik)
        {
            this.radnik = radnik;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Delete(radnik);
        }
    }
}
