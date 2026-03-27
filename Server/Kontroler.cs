using Sistemske_operacije;
using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Server
{
    public class Kontroler
    {
        private static Kontroler instance;

        public static Kontroler Instance => instance ??= new Kontroler();

        private Kontroler() { }

        public Radnik PrijaviRadnika(string korisnickoIme, string sifra)
        {
            PrijaviRadnikaSO so = new PrijaviRadnikaSO(korisnickoIme, sifra);
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Radnik> VratiSveRadnike()
        {
            VratiSveRadnikeSO so = new VratiSveRadnikeSO();
            so.ExecuteTemplate();
            return so.Result.Cast<Radnik>().ToList();
        }

        public void UbaciRezervaciju(Rezervacija rezervacija)
        {
            UbaciRezervacijuSO so = new UbaciRezervacijuSO(rezervacija);
            so.ExecuteTemplate();
        }

        public void PromeniRezervaciju(Rezervacija rezervacija)
        {
            PromeniRezervacijuSO so = new PromeniRezervacijuSO(rezervacija);
            so.ExecuteTemplate();
        }

        public void ObrisiRezervaciju(Rezervacija rezervacija)
        {
            ObrisiRezervacijuSO so = new ObrisiRezervacijuSO(rezervacija);
            so.ExecuteTemplate();
        }

        public Rezervacija PretraziRezervaciju(int id)
        {
            PretraziRezervacijuSO so = new PretraziRezervacijuSO(id);
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Rezervacija> VratiListuRezervacija(string uslov)
        {
            VratiListuRezervacijaSO so = new VratiListuRezervacijaSO(uslov);
            so.ExecuteTemplate();
            return so.Result;

        }

        public List<Korisnik> VratiSveKorisnike()
        {
            VratiSveKorisnikeSO so = new VratiSveKorisnikeSO();
            so.ExecuteTemplate();
            return so.Result.Cast<Korisnik>().ToList();
        }
    }
}
