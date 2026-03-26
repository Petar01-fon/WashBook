using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class PretraziKorisnikaSO : BaseSO
    {
        private Korisnik korisnik;
        public Korisnik Result { get; set; }

        public PretraziKorisnikaSO(Korisnik korisnik)
        {
            this.korisnik = korisnik;
        }

        protected override void ExecuteConcreteOperation()
        {
            Result = (Korisnik)broker.GetById(korisnik);
        }
    }
}
