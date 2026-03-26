using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class PretraziRezervacijuSO : BaseSO
    {
        private int idRezervacija;
        public Rezervacija Result { get; set; }

        public PretraziRezervacijuSO(int idRezervacija)
        {
            this.idRezervacija = idRezervacija;
        }

        protected override void ExecuteConcreteOperation()
        {
            Result = broker.GetRezervacija(idRezervacija);
        }
    }
}
