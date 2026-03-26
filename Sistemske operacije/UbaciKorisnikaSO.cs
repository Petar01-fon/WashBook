using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class UbaciKorisnikaSO : BaseSO
    {
        private Korisnik korisnik;

        public UbaciKorisnikaSO(Korisnik korisnik)
        {
            this.korisnik = korisnik;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Add(korisnik);
        }
    }
}
