using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class ObrisiGradSO : BaseSO
    {
        private Grad grad;

        public ObrisiGradSO(Grad grad)
        {
            this.grad = grad;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Delete(grad);
        }
    }
}
