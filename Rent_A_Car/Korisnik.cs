using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_A_Car
{
    [Serializable]
    public class Korisnik
    {
        public string sifra { get; set; }
        public string korisnickoIme { get; set; }

        public Korisnik(string sifra, string korisnickoIme) {
            this.sifra = sifra;
            this.korisnickoIme = korisnickoIme;
        }

        public override string ToString()
        {
            return this.sifra + " " + this.korisnickoIme;
        }

    }
}
