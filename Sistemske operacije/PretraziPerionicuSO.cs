using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class PretraziPerionicuSO : BaseSO
    {
        private Perionica perionica;
        public Perionica Result { get; set; }

        public PretraziPerionicuSO(Perionica perionica)
        {
            this.perionica = perionica;
        }

        protected override void ExecuteConcreteOperation()
        {
            Result = (Perionica)broker.GetById(perionica);
        }
    }
}
