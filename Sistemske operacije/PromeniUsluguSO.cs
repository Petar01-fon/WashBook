using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class PromeniUsluguSO : BaseSO
    {
        private Usluga usluga;

        public PromeniUsluguSO(Usluga usluga)
        {
            this.usluga = usluga;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Update(usluga);
        }
    }
}
