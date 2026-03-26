using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class UbaciPerionicuSO : BaseSO
    {
        private Perionica perionica;

        public UbaciPerionicuSO(Perionica perionica)
        {
            this.perionica = perionica;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Add(perionica);
        }
    }
}
