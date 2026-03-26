using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class VratiSveUsluge : BaseSO
    {
        List<Usluga> Result { get; set; }
        protected override void ExecuteConcreteOperation()
        {
            Result = broker.GetAll(new Usluga()).Cast<Usluga>().ToList();
        }
    }
}
