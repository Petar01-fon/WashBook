using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class ObrisiKorisnikaSO : BaseSO
    {
        private Korisnik korisnik;
        public ObrisiKorisnikaSO(Korisnik korisnik)
        {
            this.korisnik = korisnik;
        }
        protected override void ExecuteConcreteOperation()
        {
            broker.Delete(korisnik);
        }
    }
}
