using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rent_A_Car
{
    public class Validacija
    {

        public string output { get; set; }

        public Validacija()
        {
            output = "";
        }

        private bool slovo(char ch)
        {
            return char.IsLetter(ch);
        }

        private bool cifra(char ch)
        {
            return char.IsDigit(ch);
        }


        // VALIDACIJA AUTOMOBILA
        public bool proveriKaroseriju(ComboBox cbKaroserija)
        {

            if (cbKaroserija.SelectedItem == null)
            {
                output += "Karoserija ne sme biti prazna" + Environment.NewLine;
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool proveriBrVrata(ComboBox cbBrVrata)
        {

            if (cbBrVrata.SelectedItem == null)
            {
                output += "BrVrata ne sme biti prazan" + Environment.NewLine;
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool proveriPogon(ComboBox cbPogon)
        {

            if (cbPogon.SelectedItem == null)
            {
                output += "Pogon ne sme biti prazan" + Environment.NewLine;
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool proveriMenjac(ComboBox cbMenjac)
        {

            if (cbMenjac.SelectedItem == null)
            {
                output += "Menjač ne sme biti prazan" + Environment.NewLine;
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool proveriGorivo(ComboBox cbGorivo)
        {

            if (cbGorivo.SelectedItem == null)
            {
                output += "Gorivo ne sme biti prazno" + Environment.NewLine;
                return false;
            }
            else
            {
                return true;
            }
        }


        public bool proveriMarku(string txtMarka)
        {
            if (txtMarka.Length == 0)
            {
                output += "Marka ne sme biti prazna" + Environment.NewLine;
                return false;
            }
            else if (!txtMarka.All((ch) => char.IsLetter(ch) ))
            {
                output += "Marka mora sadržati samo slova" + Environment.NewLine;
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool proveriModel(string txtModel)
        {
            if (txtModel.Length == 0)
            {
                output += "Model ne sme biti prazan" + Environment.NewLine;
                return false;
            }
            else if (txtModel.All((ch) => char.IsDigit(ch)))
            {
                output += "Model ne sme sadržati samo brojeve" + Environment.NewLine;
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool proveriGodiste(string txtGodiste)
        {
            int godiste;
            bool prosao = int.TryParse(txtGodiste, out godiste);
            if (txtGodiste.Length == 0)
            {
                output += "Godiste ne sme biti prazno" + Environment.NewLine;
                return false;
            }
            if (!prosao)
            {
                output += "Godiste mora biti broj" + Environment.NewLine;
                return false;
            }
            else if (godiste > DateTime.Now.Year || godiste < 1990)
            {
                output += "Godiste mora biti izmedju 1990 i " + DateTime.Now.Year + Environment.NewLine;
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool proveriKubikazu(string txtKubikaza)
        {
            int kubikaza;
            bool prosao = int.TryParse(txtKubikaza, out kubikaza);

            if (txtKubikaza.Length == 0)
            {
                output += "Kubikaza ne sme biti prazna" + Environment.NewLine;
                return false;
            }
            if (!prosao)
            {
                output += "Kubikaža mora biti broj" + Environment.NewLine;
                return false;
            }
            else if (kubikaza < 500 || kubikaza > 4000)
            {
                output += "Kubikaža mora biti u opsegu od 500 do 4000" + Environment.NewLine;
                return false;
            }
            else
            {
                return true;
            }
        }


        // VALIDACIJA KREIRANJA KORISNIKA
     
        public bool proveriTelefon(string txtTelefon)
        {
            if (txtTelefon.Length == 0)
            {
                output += "Telefon ne sme biti prazan " + Environment.NewLine;
                return false;
            } else if(!txtTelefon.All((ch) => char.IsDigit(ch)))
            {
                output += "Telefon mora sadržati samo cifre" + Environment.NewLine;
                return false;
            } else if(txtTelefon.Length < 9 || txtTelefon.Length > 10)
            {
                output += "Telefon mora imati 9 ili 10 cifara" + Environment.NewLine;
                return false;
            } else if(txtTelefon[0] != '0' || txtTelefon[1] != '6')
              {
                output += "Telefon mora počinjati sa 06" + Environment.NewLine;
                return false;
              }
          

            return true;
        }
        public bool proveriJMBG(string txtJmbg)
        {
            if(!txtJmbg.All((ch) => char.IsDigit(ch)))
            {
                output += "JMBG mora sadrzati samo cifre" + Environment.NewLine;
                return false;
            } else if (txtJmbg.Length == 13)
            {
                bool prosao;
                int dan, mesec, godina, regija, jedinstveniBroj;
                int[] daniUMesecu = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            
                prosao = int.TryParse(txtJmbg.Substring(0, 2), out dan);

                // proveri dan u mesecu
                if (!prosao || (dan < 1 || dan > 31))
                {
                    output += "Pogrešan JMBG " + Environment.NewLine;
                    return false;
                }

                // proveri mesec
                prosao = int.TryParse(txtJmbg.Substring(2, 2), out mesec);

                if (!prosao || (mesec > daniUMesecu.Length || mesec < 1) || (dan > daniUMesecu[mesec - 1]))
                {
                    output += "Pogrešan JMBG " + Environment.NewLine;
                    return false;
                }

                // proveri godinu
                int trenutnaGodina = DateTime.Now.Year;

                int pom1, pom2, pom3;

                bool prvi = int.TryParse(txtJmbg.Substring(4, 1), out pom1);
                bool drugi = int.TryParse(txtJmbg.Substring(5, 1), out pom2);
                bool treci = int.TryParse(txtJmbg.Substring(6, 1), out pom3);

                if (prvi && drugi && treci)
                {
                    godina = 100 * pom1 + 10 * pom2 + pom3;
                    if (txtJmbg.Substring(4, 1) == "0") // rodjen u 21 veku
                    {
                        godina += 2000;
                    }
                    else // rodjen u 20 veku
                    {
                        godina += 1000;
                    }

                    if (godina > trenutnaGodina || godina < 1900)
                    {
                        output += "Pogrešan JMBG " + Environment.NewLine;
                        return false;
                    }
                }

                // politicka regija
                prosao = int.TryParse(txtJmbg.Substring(7, 2), out regija);

                if (!prosao || (regija < 1 || regija > 96))
                {
                    output += "Pogrešan JMBG " + Environment.NewLine;
                    return false;
                }

                // jedinstveniBroj

                prosao = int.TryParse(txtJmbg.Substring(9, 3), out jedinstveniBroj);

                if (!prosao || (jedinstveniBroj < 0 || jedinstveniBroj > 999))
                {
                    output += "Pogrešan JMBG " + Environment.NewLine;
                    return false;
                }

                // kontrolna cifra
                /*DDMMGGGRRBBBK = ABVGDĐEŽZIJKL
                L = 11 – ((7 * (A + E) + 6 * (B + Ž) + 5 * (V + Z) + 4 * (G + I) + 3 * (D + J) + 2 * (Đ + K)) % 11)*/

                char[] niz = txtJmbg.Substring(0, 13).ToCharArray();
                int zbir = 0;
                for (int i = 0; i < 6; i++)
                {
                    zbir += (7 - i) * (Convert.ToInt32(niz[i] - '0') + Convert.ToInt32(niz[6 + i] - '0'));
                }
                int ostatak = zbir % 11; // ostatak dijeljenja zbira sa 11
                int razlika = 11 - ostatak;

                if (ostatak == 1)
                {
                    output += "Pogrešan JMBG " + Environment.NewLine;
                    return false;
                }
                else if (ostatak == 0)
                {
                    if (Convert.ToInt32(niz[12] - '0') != 0)
                    {
                        output += "Pogrešan JMBG " + Environment.NewLine;
                        return false;
                    }
                }

            }
            else
            {
                output += "JMBG mora imati tačno 13 cifara " + Environment.NewLine;
                return false;
            }


            return true;
        }

        public bool jmbgPostojiAzuriranje(string txtJmbg, Kupac izabraniKupac)
        {

            List<Kupac> kupci = Global.citajIzDatoteke<Kupac>(Global.KUPAC);
            foreach (Kupac kupac in kupci)
            {
                if(kupac.jmbg.Equals(txtJmbg) && kupac.IDBR != izabraniKupac.IDBR)
                {
                    return true;
                } 
            }

            return false;
        }

        public bool jmbgPostojiKreiranje(string txtJmbg)
        {
            List<Kupac> kupci = Global.citajIzDatoteke<Kupac>(Global.KUPAC);
            foreach (Kupac kupac in kupci)
            {
                if (kupac.jmbg.Equals(txtJmbg))
                {
                    return true;
                }
            }

            return false;
        }

        public bool korisnickoImePostojiKreiranje(string txtKorisnickoIme)
        {
            List<Kupac> kupci = Global.citajIzDatoteke<Kupac>(Global.KUPAC);
            List<Admin> admini = Global.citajIzDatoteke<Admin>(Global.ADMIN);

            foreach (Kupac kupac in kupci)
            {
                if (kupac.korisnickoIme.Equals(txtKorisnickoIme))
                {
                    return true;
                }
            }

            foreach (Admin ad in admini)
            {
                if (ad.korisnickoIme.Equals(txtKorisnickoIme))
                {
                    return true;
                }
            }

            return false;
        }

        public bool korisnickoImePostojiAzuriranje(string txtKorisnickoIme, Kupac izabraniKupac)
        {
            List<Kupac> kupci = Global.citajIzDatoteke<Kupac>(Global.KUPAC);
            List<Admin> admini = Global.citajIzDatoteke<Admin>(Global.ADMIN);

            foreach (Kupac kupac in kupci)
            {
                if ( izabraniKupac.IDBR != kupac.IDBR  && kupac.korisnickoIme.Equals(txtKorisnickoIme))
                {
                    return true;
                }
            }

            foreach (Admin ad in admini)
            {
                if(ad.korisnickoIme.Equals(txtKorisnickoIme))
                {
                    return true;
                }
            }

            return false;
        }

        public bool proveriDatum(DateTime datum)
        {
            if (datum.Date > DateTime.Now.Date)
            {
                output += "Datum je veći od trenutnog datuma " + Environment.NewLine;
                return false;
            }

            return true;
        }

        public bool proveriIme(string txtIme)
        {

            if (txtIme.Length < 3)
            {
                output += "Ime mora imati više od 3 karaktera " + Environment.NewLine;
                return false;
            }


            else if (!(txtIme.All((ch) => char.IsLetter(ch))))
            {
                output += "Ime mora sadržati samo slova " + Environment.NewLine;
                return false;
            }
            else
            {
                return true;
            }


        }

        public bool proveriPrezime(string txtPrezime)
        {

            if (txtPrezime.Length < 3)
            {
                output += "Prezime mora imati više od 3 karaktera " + Environment.NewLine;
                return false;
            }
            else if (!(txtPrezime.All((ch) => char.IsLetter(ch))))
            {
                output += "Prezime mora sadržati samo slova " + Environment.NewLine;
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool proveriSifru(string txtSifra)
        {
            if (txtSifra.Length < 4 && txtSifra.Length > 15)
            {
                output += "Šifra mora imati više od 4 karaktera a manje od 16" + Environment.NewLine;
                return false;
            }

            return true;
        }

        public bool proveriPotvrduSifre(string prethodnaSifra, string trenutnaSifra)
        {
            if(!trenutnaSifra.Equals(prethodnaSifra)) {
                output += "Šifre se ne poklapaju" + Environment.NewLine;
                    return false;
            }

            return true;
        }

        public bool proveriKorisnickoIme(string txtKorisnickoIme)
        {
            if (txtKorisnickoIme.Length < 3 || txtKorisnickoIme.All((ch) => char.IsDigit(ch)))
            {
                output += "Korisničko ime mora imati više od 3 karaktera i ne sme sadržati samo brojeve" + Environment.NewLine;
                return false;
            }

            return true;
        }

        // VALIDACIJA PONUDA
        public bool proveriDatum(DateTime datumOd, DateTime datumDo)
        {
            if (datumOd < DateTime.Now.Date || datumOd > datumDo)
            {
                output += "Datum nije u odgovarajućem opsegu" + Environment.NewLine;
                return false;
            }

            return true;
        }

        public bool proverCenuPoDanu(string txtCenaPoDanu)
        {
            double cena;
            bool prosao = double.TryParse(txtCenaPoDanu, out cena);
            if(txtCenaPoDanu.Length == 0) {
                output += "Cena ne sme biti prazna" + Environment.NewLine;
                return false;
            }else if (!prosao)
            {
                output += "Cena mora biti broj" + Environment.NewLine;
                return false;
            } else if(cena < 1)
            {
                output += "Cena mora biti veća od 0" + Environment.NewLine;
                return false;
            } else
            {
                return true;
            }
        }
    }
}
