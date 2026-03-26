using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class UbaciRadnikaSO : BaseSO
    {
        private Radnik radnik;

        public UbaciRadnikaSO(Radnik radnik)
        {
            this.radnik = radnik;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Add(radnik);
        }
    }
}
