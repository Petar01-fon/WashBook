using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class VratiListuPerionica : BaseSO
    {
        private string condition;
        public List<Perionica> Result { get; set; }
        public VratiListuPerionica(string condition)
        {
            this.condition = condition;
        }
        protected override void ExecuteConcreteOperation()
        {
            Result = broker.GetAllByCondition(new Perionica(), condition).Cast<Perionica>().ToList();
        }
    }
}
