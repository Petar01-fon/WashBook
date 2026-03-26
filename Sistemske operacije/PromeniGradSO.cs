using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class PromeniGradSO : BaseSO
    {
        private Grad grad;

        public PromeniGradSO(Grad grad)
        {
            this.grad = grad;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Update(grad);
        }

    }
}
