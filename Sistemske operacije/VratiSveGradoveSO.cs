using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class VratiSveGradoveSO : BaseSO
    {
        public List<Grad> Result { get; set; }
        protected override void ExecuteConcreteOperation()
        {
            Result = broker.GetAll(new Grad()).Cast<Grad>().ToList();
        }
    }
}
