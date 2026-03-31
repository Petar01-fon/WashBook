using System;
using System.Collections.Generic;
using System.Text;

namespace Sistemske_operacije
{
    public class VratiZauzetTermineSO : BaseSO
    {
        private DateTime datum;
        public List<DateTime> Result { get; set; }

        public VratiZauzetTermineSO(DateTime datum)
        {
            this.datum = datum;
        }

        protected override void ExecuteConcreteOperation()
        {
            Result = broker.GetZauzetiTermini(datum);
        }
    }
}
