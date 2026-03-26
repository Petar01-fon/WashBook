using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class ObrisiUsluguSO : BaseSO
    {
        private Usluga usluga;

        public ObrisiUsluguSO(Usluga usluga)
        {
            this.usluga = usluga;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Delete(usluga);
        }
    }
}
