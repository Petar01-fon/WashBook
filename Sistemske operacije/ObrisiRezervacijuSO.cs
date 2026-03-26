using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class ObrisiRezervacijuSO : BaseSO
    {
        private Rezervacija rezervacija;
        public ObrisiRezervacijuSO(Rezervacija rezervacija)
        {
            this.rezervacija = rezervacija;
        }
        protected override void ExecuteConcreteOperation()
        {
            broker.Delete(rezervacija);
        }
    }
}
