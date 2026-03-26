using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class UbaciRezervacijuSO : BaseSO
    {
        private Rezervacija rezervacija;

        public UbaciRezervacijuSO(Rezervacija rezervacija)
        {
            this.rezervacija = rezervacija;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Add(rezervacija);
        }
    }
}
