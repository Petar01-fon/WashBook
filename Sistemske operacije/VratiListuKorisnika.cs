using DBBroker;
using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class VratiListuKorisnika : BaseSO
    {
        private string condition;
        public List<Korisnik> Result { get; set; }

        public VratiListuKorisnika(string condition)
        {
            this.condition = condition;
        }

        protected override void ExecuteConcreteOperation()
        {
            Result = broker.GetAllByCondition(new Korisnik(), condition).Cast<Korisnik>().ToList();
        }
    }
}
