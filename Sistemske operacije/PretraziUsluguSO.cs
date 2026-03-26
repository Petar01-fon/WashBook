using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class PretraziUsluguSO : BaseSO
    {
        private Usluga usluga;
        public Usluga Result { get; set; }

        public PretraziUsluguSO(Usluga usluga)
        {
            this.usluga = usluga;
        }

        protected override void ExecuteConcreteOperation()
        {
            Result = (Usluga)broker.GetById(usluga);
        }
    }
}
