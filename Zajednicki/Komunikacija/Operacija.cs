using System;
using System.Collections.Generic;
using System.Text;

namespace Zajednicki.Komunikacija
{
    public enum Operacija
    {
        // Radnik
        PrijaviRadnika,
        VratiSveRadnike,

        // Korisnik
        PrijaviKorisnika,
        VratiSveKorisnike,

        // Rezervacija
        UbaciRezervaciju,
        PromeniRezervaciju,
        ObrisiRezervaciju,
        PretraziRezervaciju,
        VratiListuRezervacija,
        VratiZauzeteTermine,
        StornirajRezervaciju,


        // Ostalo
        VratiSveTipoveVozila,
        VratiSveUsluge
    }
}
