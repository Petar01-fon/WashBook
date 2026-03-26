using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class VratiListuUsluga : BaseSO
    {
        private string condition;
        public List<Usluga> Result { get; set; }
        public VratiListuUsluga(string condition)
        {
            this.condition = condition;
        }
        protected override void ExecuteConcreteOperation()
        {
            Result = broker.GetAllByCondition(new Usluga(), condition).Cast<Usluga>().ToList();
        }
    }
}
