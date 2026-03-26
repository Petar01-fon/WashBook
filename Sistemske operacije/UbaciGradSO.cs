using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class UbaciGradSO : BaseSO
    {
        private Grad grad;

        public UbaciGradSO(Grad grad)
        {
            this.grad = grad;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Add(grad);
        }
    }
}
