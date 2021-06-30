using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_A_Car
{
    [Serializable]
    public class Kupac : Korisnik
    {

        public string ime { get; set; }
        public string prezime { get; set; }
        public DateTime datumRodjenja { get; set; }
        public string telefon { get; set; }
        public string jmbg { get; set; }
        public int IDBR { get; set; }

        public Kupac(string sifra, string korisnickoIme, string ime, string prezime, string jmbg, DateTime datumRodjenja, string telefon) : base(sifra, korisnickoIme)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.datumRodjenja = datumRodjenja;
            this.telefon = telefon;
            this.jmbg = jmbg;
            this.IDBR = Global.idbrKupca++;
        }

        public override string ToString()
        {
            return "Ime: " + ime + " Prezime: " + prezime + " Korisničko ime: " + korisnickoIme + " Datum rodjenja: " + datumRodjenja.ToShortDateString();
        }
    }
}
