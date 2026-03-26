using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class VratiListuGradova : BaseSO
    {
        private string condition;
        public List<Grad> Result { get; set; }
        public VratiListuGradova(string condition)
        {
            this.condition = condition;
        }
        protected override void ExecuteConcreteOperation()
        {
            Result = broker.GetAllByCondition(new Grad(), condition).Cast<Grad>().ToList();
        }
    }
}
