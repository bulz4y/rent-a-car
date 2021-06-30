using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rent_A_Car
{
    public partial class frmRezervacija : Form
    {
        public frmRezervacija(Kupac k)
        {
            InitializeComponent();
            kupac = k;
            sviAutomobili = Global.citajIzDatoteke<Automobil>(Global.AUTOMOBIL);
            rezervacije = Global.citajIzDatoteke<Rezervacija>(Global.REZERVACIJA);
            ponude = Global.citajIzDatoteke<Ponuda>(Global.PONUDA);
            automobili = new List<Automobil>();
            filtriranePonude = new List<Ponuda> ();

            if(ponude.Count == 0)
            {
                lblPonuda.Visible = true;
            }

            filter = new Filter();

            datumOd = dtDatumPreuzimanja.Value.Date;
            datumDo = dtDatumVracanja.Value.Date;

        }

        private Kupac kupac;
        Filter filter;
        private List<Automobil> sviAutomobili;
        private List<Automobil> automobili;
        private List<Rezervacija> rezervacije;
        private List<Ponuda> ponude;
        private List<Ponuda> filtriranePonude;
        private Ponuda izabranaPonuda;
        private DateTime datumOd;
        private DateTime datumDo;


        private void btnOdjava_Click(object sender, EventArgs e)
        {
            Global.odjava(this);
        }

        private void btnNazad_Click(object sender, EventArgs e)
        {
            frmKupac frm = new frmKupac(kupac);         
            frm.Show();
            this.Hide();
        }

        private void frmRezervacija_FormClosed(object sender, FormClosedEventArgs e)
        {
                Application.Exit();
            
        }

        private void frmRezervacija_Load(object sender, EventArgs e)
        {
            // filtriraj automobile u ponudi
            foreach (Automobil auto in sviAutomobili)
            {
                foreach (Ponuda ponuda in ponude)
                {
                    if(ponuda.idbrAutomobila == auto.idbr)
                    {
                        automobili.Add(auto);
                        break;
                    }
                }
            }

            // popuni comob box marka
            foreach (Automobil auto in automobili)
            {
               
                    if (!cbMarka.Items.Contains(auto.marka))
                    {
                        cbMarka.Items.Add(auto.marka);
                    }
            }
           

            // dodaj funkciju na combobox index change
            foreach (Control ctrl in Controls)
            {
                if (ctrl is ComboBox)
                {
                    ComboBox cb = ctrl as ComboBox;
                    cb.SelectedIndexChanged += filterCombo;                   
                }
            }
        }
 
        private bool filtriranje(Automobil auto)
        {

            if(!filter.marka.Equals(""))
               if (!auto.marka.Equals(filter.marka, StringComparison.CurrentCultureIgnoreCase)) { return false; }

            if(!filter.model.Equals(""))
                if (!auto.model.Equals(filter.model, StringComparison.CurrentCultureIgnoreCase)) { return false; }

            if(filter.godiste != 0)
                if (auto.godiste != filter.godiste) { return false; }

            if(!filter.karoserija.Equals(""))
                if (!auto.karoserija.Equals(filter.karoserija, StringComparison.CurrentCultureIgnoreCase)) { return false; }

            if (filter.brVrata !=  0)
                if (auto.brVrata != filter.brVrata) { return false; }

            if (filter.kubikaza != 0)
                if (auto.kubikaza != filter.kubikaza) { return false; }

            if (!filter.gorivo.Equals(""))
                if (!auto.gorivo.Equals(filter.gorivo, StringComparison.CurrentCultureIgnoreCase)) { return false; }

            if (!filter.pogon.Equals(""))
                if (!auto.pogon.Equals(filter.pogon, StringComparison.CurrentCultureIgnoreCase)) { return false; }

            if (!filter.menjac.Equals(""))
                if (!auto.vrstaMenjaca.Equals(filter.menjac, StringComparison.CurrentCultureIgnoreCase)) { return false; }

            return true;

        }

        private void azurirajSve()
        {
            if (cbGodiste.SelectedIndex < 0) { azurirajGodiste(); }
            if (cbGorivo.SelectedIndex < 0) { azurirajGorivo(); }
            if (cbMenjac.SelectedIndex < 0) { azurirajMenjac(); }
            if (cbBrVrata.SelectedIndex < 0) { azurirajBrVrata(); }
            if (cbKaroserija.SelectedIndex < 0) { azurirajkaroseriju(); }
            if (cbKubikaza.SelectedIndex < 0) { azurirajKubikazu(); }
            if (cbPogon.SelectedIndex < 0) { azurirajPogon(); }
        }

        private void ocistiSve(bool model)
        {
            if(model)
            {
                cbModel.SelectedItem = null;
                cbModel.Items.Clear();
            }

            cbGodiste.SelectedItem = null;
            cbGodiste.Items.Clear();

            cbGorivo.SelectedItem = null;
            cbGorivo.Items.Clear();

            cbKaroserija.SelectedItem = null;
            cbKaroserija.Items.Clear();

            cbBrVrata.SelectedItem = null;
            cbBrVrata.Items.Clear();

            cbMenjac.SelectedItem = null;
            cbMenjac.Items.Clear();

            cbPogon.SelectedItem = null;
            cbPogon.Items.Clear();

            cbKubikaza.SelectedItem = null;
            cbKubikaza.Items.Clear();
            
        }

        private void modelSpreman()
        {
            cbModel.Text = "Izaberite model";
            cbGodiste.Text = "";
            cbGorivo.Text = "";
            cbKaroserija.Text = "";
            cbKubikaza.Text = "";
            cbMenjac.Text = "";
            cbPogon.Text = "";
            cbBrVrata.Text = "";
        }

        private void ostatakSpreman()
        {
            cbGodiste.Text = "Izaberite godiste";
            cbGorivo.Text = "Izaberite gorivo";
            cbKaroserija.Text = "Izaberite karoseriju";
            cbKubikaza.Text = "Izaberite kubikazu";
            cbMenjac.Text = "Izaberite menjac";
            cbPogon.Text = "Izaberite pogon";
            cbBrVrata.Text = "Izaberite broj vrata";
        }

        private void filterCombo(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;

            int res;
            bool prosao;

            switch (cb.Name) {
                case "cbMarka":
                    filter.clear();
                    filter.marka = cb.GetItemText(cb.SelectedItem);
                    ocistiSve(true);
                    modelSpreman();
                    azurirajModel();
                break;

                case "cbModel":         
                    filter.clear();
                    filter.marka = cbMarka.GetItemText(cbMarka.SelectedItem);
                    filter.model = cb.GetItemText(cb.SelectedItem);
                    ocistiSve(false);
                    ostatakSpreman();
                    azurirajSve();
               break;

                case "cbGodiste":
                     prosao = int.TryParse(cb.GetItemText(cb.SelectedItem), out res);
                    if (!prosao)
                        filter.godiste = 0;
                    else filter.godiste = res;
                    ocistiTrenutni(cb, res);
                    azurirajSve();
                break;

                case "cbKaroserija":
                    filter.karoserija = cb.GetItemText(cb.SelectedItem);
                    ocistiTrenutni(cb, filter.karoserija);
                    azurirajSve();
                break;

                case "cbBrVrata":
                     prosao = int.TryParse(cb.GetItemText(cb.SelectedItem), out res);
                    if (!prosao)
                        filter.brVrata = 0;
                    else filter.brVrata = res;
                    ocistiTrenutni(cb, res);
                    azurirajSve();
                break;

                case "cbPogon":
                    filter.pogon = cb.GetItemText(cb.SelectedItem);
                    ocistiTrenutni(cb, filter.pogon);
                    azurirajSve();
                    break;

                case "cbMenjac":
                    filter.menjac = cb.GetItemText(cb.SelectedItem);
                    ocistiTrenutni(cb, filter.menjac);
                    azurirajSve();
                    break;

                case "cbGorivo":
                    filter.gorivo = cb.GetItemText(cb.SelectedItem);
                    ocistiTrenutni(cb, filter.gorivo);
                    azurirajSve();
                break;

                case "cbKubikaza":
                     prosao = int.TryParse(cb.GetItemText(cb.SelectedItem), out res);

                    if (!prosao) {
                        filter.kubikaza = 0;
                    } else { filter.kubikaza = res; }

                    ocistiTrenutni(cb, res);
                    azurirajSve();

                break;

                default:
                    break;
            }

        }

        private void ocistiTrenutni(ComboBox cb, string val)
        {
            for (int i = 0; i < cb.Items.Count; i++)
            {
                if (!cb.GetItemText(cb.Items[i]).Contains(val))
                {
                    cb.Items.RemoveAt(i);
                }
            }
        }

        private void ocistiTrenutni(ComboBox cb, int val)
        {
            for (int i = 0; i < cb.Items.Count; i++)
            {
                if (int.Parse(cb.GetItemText(cb.Items[i])) != val)
                {
                    cb.Items.RemoveAt(i);
                }
            }
        }


        private void azurirajModel() {
            foreach (Automobil auto in automobili)
            {
                if(!cbModel.Items.Contains(auto.model) && filtriranje(auto))
                {
                    cbModel.Items.Add(auto.model);
                }
            }
        }

        private void azurirajKubikazu()
        {
            cbKubikaza.Items.Clear();
            foreach (Automobil auto in automobili)
            {
                if (!cbKubikaza.Items.Contains(auto.kubikaza) && filtriranje(auto))
                {
                    cbKubikaza.Items.Add(auto.kubikaza);
                }
            }
        }

        private void azurirajGorivo()
        {
            cbGorivo.Items.Clear();
            foreach (Automobil auto in automobili)
            {
                if (!cbGorivo.Items.Contains(auto.gorivo) && filtriranje(auto))
                {
                    cbGorivo.Items.Add(auto.gorivo);
                }
            }
        }

        private void azurirajBrVrata()
        {
            cbBrVrata.Items.Clear();
            foreach (Automobil auto in automobili)
            {
                if (!cbBrVrata.Items.Contains(auto.brVrata) && filtriranje(auto))
                {
                    cbBrVrata.Items.Add(auto.brVrata);
                }
            }
        }

        private void azurirajPogon()
        {
            cbPogon.Items.Clear();
            foreach (Automobil auto in automobili)
            {
                if (!cbPogon.Items.Contains(auto.pogon) && filtriranje(auto))
                {
                    cbPogon.Items.Add(auto.pogon);
                }
            }
        }

        private void azurirajGodiste()
        {
            cbGodiste.Items.Clear();
            foreach (Automobil auto in automobili)
            {
                if (!cbGodiste.Items.Contains(auto.godiste) && filtriranje(auto))
                {
                    cbGodiste.Items.Add(auto.godiste);
                }
            }
        }

        private void azurirajkaroseriju()
        {
            cbKaroserija.Items.Clear();
            foreach (Automobil auto in automobili)
            {
                if (!cbKaroserija.Items.Contains(auto.karoserija) && filtriranje(auto))
                {
                    cbKaroserija.Items.Add(auto.karoserija);
                }
            }
        }

        private void azurirajMenjac()
        {
            cbMenjac.Items.Clear();
            foreach (Automobil auto in automobili)
            {
                if (!cbMenjac.Items.Contains(auto.vrstaMenjaca) && filtriranje(auto))
                {
                    cbMenjac.Items.Add(auto.vrstaMenjaca);
                }
            }
        }

        private void btnPrikaziTermine_Click(object sender, EventArgs e)
        {
            filtriranePonude = new List<Ponuda>();
            lbTermini.Items.Clear();
            foreach (Automobil auto in automobili)
            {
                if(filtriranje(auto))
                {
                    foreach(Ponuda p in ponude)
                    {
                        if(p.idbrAutomobila == auto.idbr)
                        {
                            filtriranePonude.Add(p);
                            lbTermini.Items.Add("IDAuto: " + auto.idbr + auto.display() + " " + p.ToString());
                        }
                    }
                }
            }
        }

        private void btnRezervisi_Click(object sender, EventArgs e)
        {
            bool preklapanjeDatuma = false;
            bool vecRezervisanAuto = false;
            if (lbTermini.SelectedIndex > -1)
            {

                foreach (Rezervacija rezervacija in rezervacije)
                {
                    if (kupac.IDBR == rezervacija.idbrKupca && izabranaPonuda.idbrAutomobila == rezervacija.idbrAutomobila)
                    {
                        vecRezervisanAuto = true;
                        break;
                    }
                }           

                // vec rezervisan auto
                if (vecRezervisanAuto)
                {
                    MessageBox.Show("Ovaj auto već imate u rezervacijama");
                    return;
                }

               


                if (datumOd >= izabranaPonuda.datumOd.Date &&
                    datumOd <= izabranaPonuda.datumDo.Date &&
                    datumDo >= datumOd.Date && 
                    datumDo <= izabranaPonuda.datumDo.Date)
                {
                    foreach (Rezervacija rezervacija in rezervacije)
                    {
                        if ((datumOd <= rezervacija.datumOd &&
                              datumDo <= rezervacija.datumOd) ||
                              (datumOd > rezervacija.datumDo && datumDo > rezervacija.datumDo))
                        {

                        }
                        else
                        {
                            preklapanjeDatuma = true;
                            break;
                        }
                    }

                    // neko je vec rezervisao u ovom opsegu
                    if (preklapanjeDatuma)
                    {
                        MessageBox.Show("Datum rezervacije se preklapa sa postojećom rezervacijom");
                        return;
                    }

                    TimeSpan dani = datumDo - datumOd;
                        double brDana = dani.TotalDays;
                        if (brDana == 0) brDana = 1;
                        Rezervacija novaRezervacija = new Rezervacija(kupac.IDBR, izabranaPonuda.idbrAutomobila, dtDatumPreuzimanja.Value, dtDatumVracanja.Value, izabranaPonuda.cenaPoDanu * brDana);

                        // upisi rezervaciju
                        rezervacije.Add(novaRezervacija);
                        Global.azurirajDatoteku<Rezervacija>(Global.REZERVACIJA, rezervacije);

                        // obrisi ponudu
                        // ponude.Remove(izabranaPonuda);
                        // Global.azurirajDatoteku<Ponuda>(Global.PONUDA, ponude);

                        MessageBox.Show("Uspešno ste rezervisali automobil");

                        btnNazad.PerformClick();
                  
                } else
                {
                    MessageBox.Show("Datum nije u odgovarajućem opsegu");
                }

            } else
            {
                MessageBox.Show("Niste izabrali nijednu ponudu");
            }

        }

       private bool proveriDatum()
       {
            if(datumOd >= izabranaPonuda.datumOd.Date &&
               datumOd <= izabranaPonuda.datumDo.Date &&
               datumDo >= datumOd.Date &&
               datumDo <= izabranaPonuda.datumDo.Date)
                {
                return true;
               
            } else
            {
                return false;
            }

        }

        private void azurirajUkupnuCenu()
        {
            if (lbTermini.SelectedIndex > -1 && proveriDatum())
            {

                TimeSpan dani = datumDo - datumOd;
                int brDana = (int)dani.TotalDays;
                if (brDana == 0) brDana = 1;
                txtUkupnaCena.Text = (izabranaPonuda.cenaPoDanu * brDana).ToString();

            }
            else
            {
                txtUkupnaCena.Text = "0";
            }
        }

        private void lbTermini_SelectedIndexChanged(object sender, EventArgs e)
        {
            izabranaPonuda = filtriranePonude[lbTermini.SelectedIndex];
            azurirajUkupnuCenu();
            

        }

        private void dtDatumPreuzimanja_ValueChanged(object sender, EventArgs e)
        {
            datumOd = dtDatumPreuzimanja.Value.Date;
            azurirajUkupnuCenu();
        }

        private void dtDatumVracanja_ValueChanged(object sender, EventArgs e)
        {
            datumDo = dtDatumVracanja.Value.Date;
            azurirajUkupnuCenu();
        }
    }
}
