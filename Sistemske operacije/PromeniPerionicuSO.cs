using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class PromeniPerionicuSO : BaseSO
    {
        private Perionica perionica;

        public PromeniPerionicuSO(Perionica perionica)
        {
            this.perionica = perionica;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Update(perionica);
        }

    }
}
