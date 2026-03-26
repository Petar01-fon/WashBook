using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class PromeniRadnikaSO : BaseSO
    {
        private Radnik radnik;

        public PromeniRadnikaSO(Radnik radnik)
        {
            this.radnik = radnik;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Update(radnik);
        }
    }
}
