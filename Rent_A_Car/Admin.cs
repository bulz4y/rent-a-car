using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_A_Car
{
    [Serializable]
    class Admin : Korisnik
    {
        public Admin(string sifra, string korisnickoIme) : base(sifra, korisnickoIme) { }
    }
}
