using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class PrijaviRadnikaSO : BaseSO
    {
        private string korisnickoIme;
        private string sifra;
        public Radnik Result { get; set; }

        public PrijaviRadnikaSO(string korisnickoIme, string sifra)
        {
            this.korisnickoIme = korisnickoIme;
            this.sifra = sifra;
        }

        protected override void ExecuteConcreteOperation()
        {
            Result = (Radnik)broker.Prijavi(new Radnik(), korisnickoIme, sifra);
        }
    }
}
