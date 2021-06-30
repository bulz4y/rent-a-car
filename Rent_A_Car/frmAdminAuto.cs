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
    public partial class frmAdminAuto : Form
    {
        public frmAdminAuto()
        {
            InitializeComponent();

            automobili = Global.citajIzDatoteke<Automobil>(Global.AUTOMOBIL);
            izabraniAutomobil = null;
            validacija = new Validacija();
         

        }

        private List<Automobil> automobili;
        Automobil izabraniAutomobil;
        DialogResult dr;
        private Validacija validacija;

        private void ocistiPolja()
        {
            txtGodiste.Text = "";
            txtKubikaza.Text = "";
            txtMarka.Text = "";
            txtModel.Text = "";
            cbBrVrata.SelectedItem = null;
            cbGorivo.SelectedItem = null;
            cbKaroserija.SelectedItem = null;
            cbMenjac.SelectedItem = null;
            cbPogon.SelectedItem = null;
        }

        private void frmAdminAuto_Load(object sender, EventArgs e)
        {

            cbMenjac.DropDownStyle = ComboBoxStyle.DropDownList;
            cbKaroserija.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPogon.DropDownStyle = ComboBoxStyle.DropDownList;
            cbBrVrata.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGorivo.DropDownStyle = ComboBoxStyle.DropDownList;

            // dodaj menjace
            cbMenjac.Items.Add("Automatski");
            cbMenjac.Items.Add("Manuelni");

            // dodaj br vrata
            cbBrVrata.Items.Add("3");
            cbBrVrata.Items.Add("4");
            cbBrVrata.Items.Add("5");

            // dodaj pogon
            cbPogon.Items.Add("Prednji");
            cbPogon.Items.Add("Zadnji");

            // dodaj gorivo
            cbGorivo.Items.Add("Dizel");
            cbGorivo.Items.Add("Benzin");
            cbGorivo.Items.Add("Gas");

            // dodaj karoseriju
            cbKaroserija.Items.Add("Limuzina");
            cbKaroserija.Items.Add("Hecbek");
            cbKaroserija.Items.Add("Karavan");
            cbKaroserija.Items.Add("Kupe");
            cbKaroserija.Items.Add("Kabriolet");
            cbKaroserija.Items.Add("Monovolumen");
            cbKaroserija.Items.Add("Dzip");
            cbKaroserija.Items.Add("Pickup");

            // dodaj automobile u listu
            azurirajListu();

           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmAdmin frm = new frmAdmin();
            frm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Global.odjava(this);
        }

        private void azurirajComboBox(ComboBox cb, string val)
        {
            for(int i = 0; i < cb.Items.Count; i++)
            {
                if(cb.Items[i].ToString().Equals(val, StringComparison.CurrentCultureIgnoreCase))
                {
                    cb.SelectedItem = cb.Items[i].ToString();
                    break;
                }
            }
        }

        private void lbAutomobili_SelectedIndexChanged(object sender, EventArgs e)
        {
           

            if (lbAutomobili.SelectedIndex > -1)
            {

                izabraniAutomobil = lbAutomobili.SelectedItem as Automobil;

                // azuriraj polja
                txtMarka.Text = izabraniAutomobil.marka;
                txtModel.Text = izabraniAutomobil.model;
                txtGodiste.Text = izabraniAutomobil.godiste.ToString();

                azurirajComboBox(cbKaroserija, izabraniAutomobil.karoserija);
                azurirajComboBox(cbMenjac, izabraniAutomobil.vrstaMenjaca);
                azurirajComboBox(cbBrVrata, izabraniAutomobil.brVrata.ToString());
                azurirajComboBox(cbGorivo, izabraniAutomobil.gorivo);
                azurirajComboBox(cbPogon, izabraniAutomobil.pogon);

                txtKubikaza.Text = izabraniAutomobil.kubikaza.ToString();
            }
        }

        private void azurirajListu()
        {
            ocistiPolja();
            lbAutomobili.Items.Clear();
            foreach (Automobil auto in automobili)
            {
                lbAutomobili.Items.Add(auto);
            }

            if(lbAutomobili.Items.Count == 0)
            {
                lblAutomobili.Visible = true;
            } else
            {
                lblAutomobili.Visible = false;
            }
        }

        private bool validacijaForme()
        {
            bool prosao = true;
            if(!validacija.proveriMarku(txtMarka.Text.Trim())) { prosao =  false; }
            if (!validacija.proveriModel(txtModel.Text.Trim())) { prosao = false; }
            if (!validacija.proveriGodiste(txtGodiste.Text.Trim())) { prosao = false; }
            if (!validacija.proveriKubikazu(txtKubikaza.Text.Trim())) { prosao = false; }
            if(!validacija.proveriBrVrata(cbBrVrata)) { prosao = false; }
            if (!validacija.proveriKaroseriju(cbKaroserija)) { prosao = false; }
            if (!validacija.proveriGorivo(cbGorivo)) { prosao = false; }
            if (!validacija.proveriMenjac(cbMenjac)) { prosao = false; }
            if (!validacija.proveriPogon(cbPogon)) { prosao = false; }


            return prosao;
        }

        private void btnAzuriraj_Click(object sender, EventArgs e)
        {
            if(lbAutomobili.SelectedIndex > -1)
            {
                if(validacijaForme())
                {
                    dr = MessageBox.Show("Da li ste sigurni da želite da ažurirate ovaj automobil ?", "Azuriranje", MessageBoxButtons.YesNo);

                    if (dr == DialogResult.Yes)
                    {
                        foreach (Automobil auto in automobili)
                        {
                            if(auto.idbr == izabraniAutomobil.idbr)
                            {
                                auto.marka = txtMarka.Text.Trim().ToLower();
                                auto.model = txtModel.Text.Trim().ToLower();
                                auto.kubikaza = int.Parse(txtKubikaza.Text.Trim());
                                auto.godiste = int.Parse(txtGodiste.Text.Trim());
                                auto.vrstaMenjaca = cbMenjac.GetItemText(cbMenjac.SelectedItem).ToLower();
                                auto.pogon = cbPogon.GetItemText(cbPogon.SelectedItem).ToLower();
                                auto.karoserija = cbKaroserija.GetItemText(cbKaroserija.SelectedItem).ToLower();
                                auto.brVrata = int.Parse(cbBrVrata.GetItemText(cbBrVrata.SelectedItem));
                                auto.gorivo = cbGorivo.GetItemText(cbGorivo.SelectedItem).ToLower();

                                //azuriraj datoteku
                                Global.azurirajDatoteku<Automobil>(Global.AUTOMOBIL, automobili);

                                MessageBox.Show("Uspesno ste ažurirali automobil");

                                // azuriraj listu
                                azurirajListu();

                                break;
                            }
                        }
                       
                    } 
                   
                } else
                {
                    MessageBox.Show(validacija.output);
                }
            } else
            {
                MessageBox.Show("Nsite izabrali nijedan auto");
            }

            validacija.output = "";
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if(lbAutomobili.SelectedIndex > -1)
            {
                List<Rezervacija> rezervacije = Global.citajIzDatoteke<Rezervacija>(Global.REZERVACIJA);
                bool rezervisan = false;
                foreach (Rezervacija rezervacija in rezervacije)
                {
                    if(izabraniAutomobil.idbr == rezervacija.idbrAutomobila)
                    {
                        rezervisan = true;
                        break;
                    }
                }

                if(rezervisan)
                {
                    MessageBox.Show("Ne mozete obrisati ovaj auto jer je rezervisan");
                    return;
                }

                dr = MessageBox.Show("Da li ste sigurni da želite da obrišete ovaj automobil ?", "Brisanje", MessageBoxButtons.YesNo);

                if(dr == DialogResult.Yes)
                {
                    // izbrisi automobil 
                    automobili.Remove(izabraniAutomobil);

                    // izbrisi automobil iz ponude i rezervacija

                    List<Ponuda> ponude = Global.citajIzDatoteke<Ponuda>(Global.PONUDA);
                    List<Ponuda> copyPonude = new List<Ponuda>(ponude);

                    for (int i = 0; i < copyPonude.Count; i++)
                    {
                        if(izabraniAutomobil.idbr == copyPonude[i].idbrAutomobila)
                        {
                            ponude.RemoveAt(i);
                        }
                    }

                    // azuriraj automobile
                    Global.azurirajDatoteku<Automobil>(Global.AUTOMOBIL, automobili);

                    // azuriraj ponude
                    Global.azurirajDatoteku<Ponuda>(Global.PONUDA, ponude);

                    MessageBox.Show("Uspešno ste obrisali izabrani automobil");

                    azurirajListu();
                }

            } else
            {
                MessageBox.Show("Niste izabrali Automobil");
            }
        }

        private void frmAdminAuto_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnNovi_Click(object sender, EventArgs e)
        {
          
           if(validacijaForme())
            {
                dr = MessageBox.Show("Da li ste sigurni da želite da dodate novi automobil ?", "Dodavanje", MessageBoxButtons.YesNo);

              
                if (dr == DialogResult.Yes)
                {
                    // kreiraj novi automobil
                    Automobil noviAuto = new Automobil(txtMarka.Text.Trim(), txtModel.Text.Trim(), int.Parse(txtGodiste.Text.Trim()), int.Parse(txtKubikaza.Text.Trim()), cbPogon.SelectedItem.ToString(), cbMenjac.SelectedItem.ToString(), cbKaroserija.SelectedItem.ToString(), cbGorivo.SelectedItem.ToString(), int.Parse(cbBrVrata.SelectedItem.ToString()));
                    
                    // dodaj automobil 
                    automobili.Add(noviAuto);

                    // azuriraj datoteku
                    Global.azurirajDatoteku<Automobil>(Global.AUTOMOBIL, automobili);

                    MessageBox.Show("Uspešno ste dodali novi automobil");

                    azurirajListu();
                }
            } else
            {
                MessageBox.Show(validacija.output);
            }

            validacija.output = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ocistiPolja();
        }
    }
}
