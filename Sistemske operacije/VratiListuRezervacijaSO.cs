using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class VratiListuRezervacijaSO : BaseSO
    {
        private string condition;
        public List<Rezervacija> Result { get; set; }

        public VratiListuRezervacijaSO(string condition)
        {
            this.condition = condition;
        }

        protected override void ExecuteConcreteOperation()
        {
            //Result = broker.GetAllByCondition(new Rezervacija(), condition)
            //              .Cast<Rezervacija>().ToList();

            Result = broker.GetAllRezervacijeByCondition(condition)
               .Cast<Rezervacija>().ToList();
        }
    }
}
