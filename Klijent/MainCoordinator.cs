using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Klijent
{
    public class MainCoordinator
    {
        private static MainCoordinator instanca;
        public static MainCoordinator Instanca => instanca ??= new MainCoordinator();

        private MainCoordinator() { }

        public Radnik PrijavljeniRadnik { get; set; }
        public Korisnik PrijavljeniKorisnik { get; set; }

        private Form aktivnaForma;

        public void PrikaziFormu(Form forma)
        {
            if (aktivnaForma != null)
            {
                aktivnaForma.Hide();
            }
            aktivnaForma = forma;
            aktivnaForma.Show();
        }

        public void PrijaviRadnika(Radnik radnik)
        {
            PrijavljeniRadnik = radnik;
            PrijavljeniKorisnik = null;
            PrikaziFormu(new FrmGlavnaRadnik());

        }

        public void PrijaviKorisnika(Korisnik korisnik)
        {
            PrijavljeniKorisnik = korisnik;
            PrijavljeniRadnik = null;
            PrikaziFormu(new FrmGlavnaKorisnik());
        }

        public void Odjavi()
        {
            PrijavljeniRadnik = null;
            PrijavljeniKorisnik = null;
            aktivnaForma.Close();
            PrikaziFormu(new FrmPrijava());
        }
    }
}
