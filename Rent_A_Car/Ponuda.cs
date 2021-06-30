using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_A_Car
{
    [Serializable]
    public class Ponuda
    {
        public int idbrAutomobila { get; set; }
        public DateTime datumOd { get; set; }
        public DateTime datumDo { get; set; }
        public double cenaPoDanu { get; set; }

        public Ponuda(int idbrAutomobila, DateTime datumOd, DateTime datumDo, double cenaPoDanu)
        {
            this.idbrAutomobila = idbrAutomobila;
            this.datumOd = datumOd;
            this.datumDo = datumDo;
            this.cenaPoDanu = cenaPoDanu;
        }

        public override string ToString()
        {
            return this.datumOd.Day + "." + this.datumOd.Month + "." + this.datumOd.Year + " - " + this.datumDo.Day + "." + this.datumDo.Month + "." + this.datumDo.Year + " cena: " + this.cenaPoDanu + "din";
        }
    }
}
