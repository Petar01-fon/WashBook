using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class PrijavaKorisnikaSO : BaseSO
    {
        private string korisnickoIme;
        private string sifra;
        public Korisnik Result { get; set; }

        public PrijavaKorisnikaSO(string korisnickoIme, string sifra)
        {
            this.korisnickoIme = korisnickoIme;
            this.sifra = sifra;
        }

        protected override void ExecuteConcreteOperation()
        {
            Result = (Korisnik)broker.Prijavi(new Korisnik(), korisnickoIme, sifra);
        }
    }
}
