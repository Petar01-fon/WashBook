using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class StornirajRezervacijuSO : BaseSO
    {
        private int idRezervacije;

        public StornirajRezervacijuSO(int idRezervacije)
        {
            this.idRezervacije = idRezervacije;
        }

        protected override void ExecuteConcreteOperation()
        {
            Rezervacija rezervacija = (Rezervacija)broker.GetRezervacija(idRezervacije);


            if (rezervacija.StatusRezervacije != StatusRezervacije.KREIRANA)
                throw new Exception("Nije moguće stornirati rezervaciju koja nije u statusu KREIRANA.");

            if(rezervacija.Termin < DateTime.Now)
                throw new Exception("Nije moguće stornirati rezervaciju čiji je termin prošao.");

            rezervacija.StatusRezervacije = StatusRezervacije.STORNIRANA;
            broker.Update(rezervacija);

        }
    }
}
