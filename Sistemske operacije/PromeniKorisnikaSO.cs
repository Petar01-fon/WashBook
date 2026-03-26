using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class PromeniKorisnikaSO : BaseSO
    {
        private Korisnik korisnik;

        public PromeniKorisnikaSO(Korisnik korisnik)
        {
            this.korisnik = korisnik;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Update(korisnik);
        }
    }
}
