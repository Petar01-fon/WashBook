using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class UbaciUsluguSO : BaseSO
    {
        private Usluga usluga;

        public UbaciUsluguSO(Usluga usluga)
        {
            this.usluga = usluga;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Add(usluga);
        }
    }
}
