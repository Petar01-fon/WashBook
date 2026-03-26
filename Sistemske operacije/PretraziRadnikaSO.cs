using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class PretraziRadnikaSO : BaseSO
    {
        private Radnik radnik;
        public Radnik Result { get; set; }

        public PretraziRadnikaSO(Radnik radnik)
        {
            this.radnik = radnik;
        }

        protected override void ExecuteConcreteOperation()
        {
            Result = (Radnik)broker.GetById(radnik);
        }
    }
}
