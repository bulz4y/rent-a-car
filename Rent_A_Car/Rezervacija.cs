using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_A_Car
{
    [Serializable]
    public class Rezervacija
    {
        public int idbrKupca { get; set; }
        public int idbrAutomobila { get; set; }
        public DateTime datumOd { get; set; }
        public DateTime datumDo { get; set; }
        public double cena { get; set; }

        public Rezervacija(int idbrKupca, int idbrAutomobila, DateTime datumOd, DateTime datumDo, double cena)
        {
            this.idbrKupca = idbrKupca;
            this.idbrAutomobila = idbrAutomobila;
            this.datumDo = datumDo;
            this.datumOd = datumOd;
            this.cena = cena;
        }

        public override string ToString()
        {
            return "Od: " + this.datumOd.Day + " / " + this.datumOd.Month + " / "  + this.datumOd.Year + " Do: " + this.datumDo.Day + " / " + this.datumDo.Month + " / " +  this.datumDo.Year + " Cena: " + this.cena + " din.";
        }
    }
}
