using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class ObrisiPerionicuSO : BaseSO
    {
        private Perionica perionica;

        public ObrisiPerionicuSO(Perionica perionica)
        {
            this.perionica = perionica;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Delete(perionica);
        }
    }
}
