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
        UbaciRadnika,
        PromeniRadnika,
        ObrisiRadnika,
        PretraziRadnika,

        // Korisnik
        PrijaviKorisnika,
        VratiSveKorisnike,
        UbaciKorisnika,
        PromeniKorisnika,
        ObrisiKorisnika,
        PretraziKorisnika,

        // Rezervacija
        UbaciRezervaciju,
        PromeniRezervaciju,
        ObrisiRezervaciju,
        PretraziRezervaciju,
        VratiListuRezervacija,

        // Ostalo
        VratiSveGradove,
        VratiSvePerioniace,
        VratiSveTipoveVozila,
        VratiSveUsluge
    }
}
