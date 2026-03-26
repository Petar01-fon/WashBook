using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class PromeniRezervacijuSO : BaseSO
    {
        private Rezervacija rezervacija;

        public PromeniRezervacijuSO(Rezervacija rezervacija)
        {
            this.rezervacija = rezervacija;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Update(rezervacija);
        }
    }
}
