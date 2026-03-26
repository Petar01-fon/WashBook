using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class VratiSveTipoveVozilaSO : BaseSO
    {
        List<TipVozila> Result { get; set; }
        protected override void ExecuteConcreteOperation()
        {
            Result = broker.GetAll(new TipVozila()).Cast<TipVozila>().ToList();
        }
    }
}
