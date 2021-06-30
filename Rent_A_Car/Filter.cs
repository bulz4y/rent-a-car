using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_A_Car
{
    public class Filter
    {
        public  string model { get; set; }
        public  string marka { get; set; }
        public  int godiste { get; set; }
        public  string karoserija { get; set; }
        public  string menjac { get; set; }
        public  int brVrata { get; set; }
        public  string gorivo { get; set; }
        public  string pogon { get; set; }
        public  int kubikaza { get; set; }

        public Filter()
        {
            model = "";
            marka = "";
            godiste = 0;
            karoserija = "";
            menjac = "";
            brVrata = 0;
            gorivo = "";
            pogon = "";
            kubikaza = 0;
        }

        public void clear()
        {
            model = "";
            marka = "";
            godiste = 0;
            karoserija = "";
            menjac = "";
            brVrata = 0;
            gorivo = "";
            pogon = "";
            kubikaza = 0;
        }
    }
}
