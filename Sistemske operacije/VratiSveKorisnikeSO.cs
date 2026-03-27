using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class VratiSveKorisnikeSO : BaseSO
    {
        public List<Korisnik> Result { get; set; }
        protected override void ExecuteConcreteOperation()
        {
            Result = broker.GetAll(new Korisnik()).Cast<Korisnik>().ToList();
        }
    }
}
