using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_A_Car
{
    [Serializable]
    public class Automobil
    {
        public int idbr { get; set; }
        public string marka { get; set; }
        public string model { get; set; }
        public int godiste { get; set; }
        public int kubikaza { get; set; }
        public string pogon { get; set; }
        public string vrstaMenjaca { get; set; }
        public string karoserija { get; set; }
        public string gorivo { get; set; }
        public int brVrata { get; set; }

        public Automobil(string marka, string model, int godiste, int kubikaza, string pogon, string vrstaMenjaca, string karoserija, string gorivo, int brVrata) {
            this.idbr = Global.idbrAutomobila++;
            this.marka = marka;
            this.model = model;
            this.godiste = godiste;
            this.kubikaza = kubikaza;
            this.pogon = pogon;
            this.vrstaMenjaca = vrstaMenjaca;
            this.karoserija = karoserija;
            this.gorivo = gorivo;
            this.brVrata = brVrata;
        }

        public string display()
        {
            return " ( " + this.marka + " " + this.model + " " + this.godiste + " ) ";
        }

        public override string ToString()
        {
            return idbr + " " + marka + " " + model + " " + godiste + " " + kubikaza + " kubika " + karoserija + " " + gorivo + " " + vrstaMenjaca + " menjač " + brVrata + " vrata " + pogon + " pogon";
        }
    }
}
