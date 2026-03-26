using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class VratiSveRadnikeSO : BaseSO
    {
        public List<Radnik> Result { get; set; }
        protected override void ExecuteConcreteOperation()
        {
            Result = broker.GetAll(new Radnik()).Cast<Radnik>().ToList();
        }
    }
}
