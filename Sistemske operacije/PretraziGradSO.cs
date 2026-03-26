using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class PretraziGradSO : BaseSO
    {
        private Grad grad;
        public Grad Result { get; set; }

        public PretraziGradSO(Grad grad)
        {
            this.grad = grad;
        }

        protected override void ExecuteConcreteOperation()
        {
            Result = (Grad)broker.GetById(grad);
        }
    }
}
