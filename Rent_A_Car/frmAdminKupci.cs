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
    public partial class frmAdminKupci : Form
    {
        public frmAdminKupci()
        {
            InitializeComponent();
            kupci = Global.citajIzDatoteke<Kupac>(Global.KUPAC);
            izabraniKupac = null;
            validacija = new Validacija();
        }

        private List<Kupac> kupci;
        private Kupac izabraniKupac;
        private DialogResult dr;
        private Validacija validacija;

        private void frmAdminKupci_Load(object sender, EventArgs e)
        {
            azurirajListu();

        }

        private void ocistiPolja()
        {
            txtIme.Text = "";
            txtPrezime.Text = "";
            txtSifra.Text = "";
            txtPotvrdiSifru.Text = "";
            txtTelefon.Text = "";
            txtKorisnickoIme.Text = "";
            txtJmbg.Text = "";
            dtDatum.Value = DateTime.Now;
        }

        private void azurirajListu()
        {
            ocistiPolja();
            lbKupci.Items.Clear();
            foreach (Kupac kupac in kupci)
            {
                lbKupci.Items.Add(kupac);
            }

            if(lbKupci.Items.Count == 0)
            {
                lblKupci.Visible = true;
            } else
            {
                lblKupci.Visible = false;
            }
        }


        private void lbKupci_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lbKupci.SelectedIndex > -1)
            {

                izabraniKupac = lbKupci.SelectedItem as Kupac;

                // azuriraj polja
                txtKorisnickoIme.Text = izabraniKupac.korisnickoIme;
                txtIme.Text = izabraniKupac.ime;
                txtPrezime.Text = izabraniKupac.prezime;
                txtSifra.Text = izabraniKupac.sifra;

                txtPotvrdiSifru.Text = izabraniKupac.sifra;
                txtTelefon.Text = izabraniKupac.telefon;
                txtJmbg.Text = izabraniKupac.jmbg;

                dtDatum.Value = izabraniKupac.datumRodjenja;

            }
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {

            if (lbKupci.SelectedIndex > -1)
            {
              

                dr = MessageBox.Show("Da li ste sigurni da želite da obrišete ovog kupca ?", "Brisanje", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    // izbrisi automobil 
                    kupci.Remove(izabraniKupac);

                    // izbrisi rezervacije kupca
                    List<Rezervacija> rezervacije = Global.citajIzDatoteke<Rezervacija>(Global.REZERVACIJA);
                    List<Rezervacija> copyRezervacije = new List<Rezervacija>(rezervacije);

                    for (int i = 0; i < copyRezervacije.Count; i++)
                    {
                        if (izabraniKupac.IDBR == copyRezervacije[i].idbrKupca)
                        {
                            rezervacije.RemoveAt(i);
                        }
                    }

                    // azuriraj kupce
                    Global.azurirajDatoteku<Kupac>(Global.KUPAC, kupci);

                    // azuiraj reervacije
                    Global.azurirajDatoteku<Rezervacija>(Global.REZERVACIJA, rezervacije);

                    // azuriraj
                    MessageBox.Show("Uspešno ste obrisali izabranog kupca");

                    azurirajListu();
                }

            }
            else
            {
                MessageBox.Show("Niste izabrali Automobil");
            }
        }

        private bool validacijaForme()
        {
            bool prosao = true;

            if (!validacija.proveriKorisnickoIme(txtKorisnickoIme.Text.Trim())) { prosao = false; }
            if (!validacija.proveriSifru(txtSifra.Text.Trim())) { prosao = false; }
            if (!validacija.proveriPotvrduSifre(txtSifra.Text.Trim(), txtPotvrdiSifru.Text.Trim())) { prosao = false; }
            if (!validacija.proveriIme(txtIme.Text.Trim())) { prosao = false; }
            if (!validacija.proveriPrezime(txtPrezime.Text.Trim())) { prosao = false; }
            if (!validacija.proveriJMBG(txtJmbg.Text.Trim())) { prosao = false; }
            if (!validacija.proveriDatum(dtDatum.Value)) { prosao = false; }
            if (!validacija.proveriTelefon(txtTelefon.Text.Trim())) { prosao = false; }


            return prosao;
        }

        private void btnAzuriraj_Click(object sender, EventArgs e)
        {
            if (lbKupci.SelectedIndex > -1)
            {
                if (validacijaForme())
                {


                    if (validacija.korisnickoImePostojiAzuriranje(txtKorisnickoIme.Text.Trim(), izabraniKupac))
                    {
                        MessageBox.Show("Korisničko ime već postoji");
                        return;
                    }

                    if (validacija.jmbgPostojiAzuriranje(txtJmbg.Text.Trim(), izabraniKupac))
                    {
                        MessageBox.Show("JMBG već postoji");
                            return;
                    }

                 

                    dr = MessageBox.Show("Da li ste sigurni da želite da ažurirate ovog kupca ?", "Ažuriranje", MessageBoxButtons.YesNo);

                    if (dr == DialogResult.Yes)
                    {
                        foreach (Kupac kupac in kupci)
                        {
                            if (kupac.IDBR == izabraniKupac.IDBR)
                            {
                                kupac.ime = txtIme.Text.Trim().ToLower();
                                kupac.prezime = txtPrezime.Text.Trim().ToLower();
                                kupac.sifra = txtSifra.Text.Trim();
                                kupac.jmbg = txtJmbg.Text.Trim();
                                kupac.korisnickoIme = txtKorisnickoIme.Text.Trim();
                                kupac.telefon = txtTelefon.Text.Trim();
                                kupac.datumRodjenja = dtDatum.Value;

                                //azuriraj datoteku
                                Global.azurirajDatoteku<Kupac>(Global.KUPAC, kupci);

                                MessageBox.Show("Uspesno ste ažurirali kupca");

                                // azuriraj listu
                                azurirajListu();

                                break;
                            }
                        }

                    }

                }
                else
                {
                    MessageBox.Show(validacija.output);
                }
            }
            else
            {
                MessageBox.Show("Nsite izabrali nijednog kupca");
            }

            validacija.output = "";
        }

        private void btnNovi_Click(object sender, EventArgs e)
        {
            if (validacijaForme())
            {


                  if(validacija.korisnickoImePostojiKreiranje(txtKorisnickoIme.Text.Trim()))
                {
                    MessageBox.Show("Korisničko ime već postoji");
                    return;
                }

                if (validacija.jmbgPostojiKreiranje(txtJmbg.Text.Trim()))
                {
                    MessageBox.Show("JMBG već postoji");
                    return;
                }

                dr = MessageBox.Show("Da li ste sigurni da želite da dodate novog kupca ?", "Dodavanje", MessageBoxButtons.YesNo);


                if (dr == DialogResult.Yes)
                {
                    // kreiraj novog kupca
                    Kupac noviKupac = new Kupac(txtSifra.Text.Trim(), txtKorisnickoIme.Text.Trim(), txtIme.Text.Trim(), txtPrezime.Text.Trim(), txtJmbg.Text.Trim(), dtDatum.Value, txtTelefon.Text.Trim());

                    // dodaj kupca 
                    kupci.Add(noviKupac);

                    // azuriraj datoteku
                    Global.azurirajDatoteku<Kupac>(Global.KUPAC, kupci);

                    MessageBox.Show("Uspešno ste dodali novog kupca");

                    azurirajListu();
                }
            }
            else
            {
                MessageBox.Show(validacija.output);
            }

            validacija.output = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Global.odjava(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmAdmin frm = new frmAdmin();
            frm.Show();
            this.Hide();
        }

        private void frmAdminKupci_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnOcisti_Click(object sender, EventArgs e)
        {
            ocistiPolja();
        }
    }
}
