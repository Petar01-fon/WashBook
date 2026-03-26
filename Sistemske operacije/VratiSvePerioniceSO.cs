using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class VratiSvePerioniceSO : BaseSO
    {
        public List<Perionica> Result { get; set; }
        protected override void ExecuteConcreteOperation()
        {
            Result = broker.GetAll(new Perionica()).Cast<Perionica>().ToList();
        }
    }
}
